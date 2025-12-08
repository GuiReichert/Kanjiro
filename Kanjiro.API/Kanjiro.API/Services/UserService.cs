using Kanjiro.API.Database;
using Kanjiro.API.Models.DTO_s;
using Kanjiro.API.Services.Interfaces;
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

        public async Task<UserDTO> SynchronizeChanges(UserDTO user)
        {
            var currentUser = await _context.Users.Include(x => x.Settings).Include(x => x.Decks).ThenInclude(x => x.Cards).ThenInclude(x => x.Info).FirstOrDefaultAsync(x => x.Id == user.Id);

            if (currentUser == null) throw new Exception("Não foi possível encontrar a conta para sincronizar");



            //currentUser.Settings.Setting = 

            foreach (var incomingDeck in user.Decks)        //TODO: Melhorar essa desgrama
            {
                var currentDeck = currentUser.Decks.FirstOrDefault(x => x.Id == incomingDeck.Id);
                if (currentDeck == null) throw new Exception("Erro ao sincronizar Decks.");

                currentDeck.Name = incomingDeck.Name;

                foreach (var incomingCard in incomingDeck.Cards)
                {
                    var currentCard = currentDeck.Cards.FirstOrDefault(x => x.Id == incomingCard.Id);
                    if (currentCard == null) throw new Exception("Erro ao sincronizar Cartas.");

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
                AccountType = currentUser.AccountType,
                Decks = currentUser.Decks,
                Settings = currentUser.Settings,
            };

            return userDTO;
        }
    }
}
