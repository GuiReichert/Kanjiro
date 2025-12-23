using Kanjiro.API.Database;
using Kanjiro.API.Enums;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Services
{
    public class PlacementTestService : IPlacementTestService
    {
        private IDeckService _deckService;
        private Kanjiro_Context _context;

        public PlacementTestService(Kanjiro_Context context, IDeckService deckService)
        {
            _deckService = deckService;
            _context = context;
        }

        public async Task<List<CardInfo>> GetPlacementTestCardsByLevel(JLPT_Level level)
        {
            var cardInfos = await _context.CardInfos.Where(x => x.Level == level).Take(20).AsNoTracking().ToListAsync();    // TODO: Implementar lógica melhor para pegar cartas aleatoriamente do nível

            if (cardInfos == null || cardInfos.Count == 0) throw new KanjiroCustomException($"Ocorreu um erro ao tentar obter cartas para o nivelamento do nível {level}");

            return cardInfos;
        }

        public async Task<Deck> GetPlacementTestResults(int userId, int correctAnswers)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new KanjiroCustomException("Não foi possível encontrar o usuário para finalizar a prova de nivelamento.");

            var newDeck = new Deck { UserId = userId, Name = "PlacementResultDeck" };

            _context.Decks.Add(newDeck);

            var graduatedKanjisToAdd = new List<CardInfo>(); //TODO: Implementar lógica de adição das cartas baseado no nível

            var now = DateTime.UtcNow;

            foreach (var kanjiInfo in graduatedKanjisToAdd)
            {
                var graduatedCard = new Card
                {
                    Info = kanjiInfo,
                    NextReviewDate = DateTime.UtcNow,
                    State = Enums.CardState.NEW,
                    DeckId = newDeck.Id,
                    MistakeCounter = 0,
                    CurrentDifficultyMultiplier = 1,
                    ReviewDateCounter = 0,
                    UserComment = string.Empty,
                };

                newDeck.Cards.Add(graduatedCard);
            }

            var newCards = await _deckService.GetNextCardsToLearn(newDeck); //TODO: Implementar lógica de adição das cartas baseado no nível

            foreach (var kanjiInfo in newCards)
            {
                var newCard = new Card
                {
                    Info = kanjiInfo,
                    NextReviewDate = DateTime.UtcNow,
                    State = Enums.CardState.NEW,
                    DeckId = newDeck.Id,
                    MistakeCounter = 0,
                    CurrentDifficultyMultiplier = 1,
                    ReviewDateCounter = 0,
                    UserComment = string.Empty,
                };

                newDeck.Cards.Add(newCard);
            }

            // await _context.Decks.AddAsync(newDeck);

            return newDeck;
        }
    }
}
