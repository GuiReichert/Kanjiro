using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils.Enums;
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

        public async Task<List<CardInfo>> GetPlacementTestCardsByLevel()
        {
            var cardInfos = await _context.CardInfos
                .FromSqlRaw(@"
                    SELECT *
                    FROM (
                        SELECT *,
                               ROW_NUMBER() OVER (PARTITION BY Level ORDER BY NEWID()) AS rn
                        FROM CardInfos
                    ) t
                    WHERE rn <= 40
                ")
                .AsNoTracking()
                .OrderByDescending(x => x.Level)
                .ToListAsync();

            if (cardInfos == null || cardInfos.Count == 0) throw new KanjiroCustomException($"Ocorreu um erro ao tentar obter cartas para o nivelamento");

            return cardInfos;
        }

        public async Task<Deck> GetPlacementTestResults(int userId, JLPT_Level level, int correctAnswers)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (level == JLPT_Level.NONE) throw new KanjiroCustomException("Não foi possível determinar o nível final da sua prova de nivelamento");

                    var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                    if (user == null) throw new KanjiroCustomException("Não foi possível encontrar o usuário para finalizar a prova de nivelamento.");

                    var newDeck = new Deck { Name = "PlacementResultDeck" };
                    user.Decks.Add(newDeck);

                    int cardQtToTake = 0;

                    if (correctAnswers > 3)
                    {
                        switch (level)              // TODO: Organizar esse treco
                        {
                            case JLPT_Level.N5:
                                cardQtToTake = (correctAnswers - 1) * 2;
                                break;
                            case JLPT_Level.N4:
                                cardQtToTake = (correctAnswers - 2) * 4;
                                break;
                            case JLPT_Level.N3:
                                cardQtToTake = (correctAnswers - 3) * 9;
                                break;
                            case JLPT_Level.N2:
                                cardQtToTake = (correctAnswers - 3) * 9;
                                break;
                            case JLPT_Level.N1:
                                cardQtToTake = (correctAnswers - 5) * 30;
                                break;
                        }
                    }

                    var graduatedKanjisToAdd = await _context.CardInfos
                        .Where(x => x.Level > level)
                        .Concat(_context.CardInfos.Where(x => x.Level == level).Take(cardQtToTake))
                        .ToListAsync();

                    var now = DateTime.UtcNow;

                    foreach (var kanjiInfo in graduatedKanjisToAdd)
                    {
                        var graduatedCard = new Card
                        {
                            Info = kanjiInfo,
                            NextReviewDate = DateTime.UtcNow,
                            State = CardState.GRADUATED,
                            DeckId = newDeck.Id,
                            MistakeCounter = 0,
                            CurrentDifficultyMultiplier = 1,
                            ReviewDateCounter = 0,
                            UserComment = string.Empty,
                        };

                        newDeck.Cards.Add(graduatedCard);
                    }

                    var existingCardIds = newDeck.Cards.Select(x => x.Info.Id).ToList();

                    var newCards = await _context.CardInfos
                        .Where(x => !existingCardIds.Contains(x.Id))
                        .OrderByDescending(x => x.Level)
                        .ThenBy(x => x.Id)
                        .Take(10).
                        ToListAsync();

                    foreach (var kanjiInfo in newCards)
                    {
                        var newCard = new Card
                        {
                            Info = kanjiInfo,
                            NextReviewDate = DateTime.UtcNow,
                            State = CardState.NEW,
                            DeckId = newDeck.Id,
                            MistakeCounter = 0,
                            CurrentDifficultyMultiplier = 1,
                            ReviewDateCounter = 0,
                            UserComment = string.Empty,
                        };

                        newDeck.Cards.Add(newCard);
                    }

                    await _context.Decks.AddAsync(newDeck);
                    await _context.SaveChangesAsync();

                    user.CurrentActiveDeckId = newDeck.Id;
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return newDeck;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

        }
    }
}
