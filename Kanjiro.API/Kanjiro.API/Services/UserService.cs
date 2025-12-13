using Kanjiro.API.Database;
using Kanjiro.API.Models.DTO_s;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Services
{
    public class UserService : IUserService
    {
        private Kanjiro_Context _context;

        public UserService(Kanjiro_Context context)
        {
            _context = context;
        }

        public async Task<UserDTO> SynchronizeChanges(UserDTO user) //TODO: Melhorar essa desgrama
        {
            var currentUser = await _context.Users.Include(x => x.Settings).Include(x => x.Decks).ThenInclude(x => x.Cards).ThenInclude(x => x.Info).FirstOrDefaultAsync(x => x.Id == user.Id);

            if (currentUser == null) throw new KanjiroCustomException("Não foi possível encontrar a conta para sincronizar");

            //User
            currentUser.LastSyncDate = DateTime.UtcNow;
            currentUser.NickName = user.NickName;


            //Settings

            currentUser.Settings.darkMode = user.Settings.darkMode;
            currentUser.Settings.allowNotifications = user.Settings.allowNotifications;

            //Decks

            foreach (var incomingDeck in user.Decks)
            {
                var currentDeck = currentUser.Decks.FirstOrDefault(x => x.Id == incomingDeck.Id);
                if (currentDeck == null) throw new KanjiroCustomException("Erro ao sincronizar Decks.");

                currentDeck.Name = incomingDeck.Name;

                //Cards

                foreach (var incomingCard in incomingDeck.Cards)
                {
                    if (incomingCard.Id == 0)  // Carta adicionada ao deck pelo usuário
                    {
                        currentDeck.Cards.Add(incomingCard);
                        continue;
                    }

                    var currentCard = currentDeck.Cards.FirstOrDefault(x => x.Id == incomingCard.Id);
                    if (currentCard == null) throw new KanjiroCustomException("Erro ao sincronizar Cartas.");

                    currentCard.NextReviewDate = incomingCard.NextReviewDate;
                    currentCard.ReviewDateCounter = incomingCard.ReviewDateCounter;
                    currentCard.State = incomingCard.State;
                    currentCard.CurrentDifficultyMultiplier = incomingCard.CurrentDifficultyMultiplier;
                    currentCard.MistakeCounter = incomingCard.MistakeCounter;
                }
            }

            //TODO: Adicionar novas cartas ao deck caso necessário

            var userDTO = new UserDTO
            {
                Id = currentUser.Id,
                UserName = currentUser.UserName,
                NickName = currentUser.NickName,
                LastSyncDate = currentUser.LastSyncDate,
                AccountType = currentUser.AccountType,
                Decks = currentUser.Decks,
                Settings = currentUser.Settings,
            };

            return userDTO;
        }
    }
}
