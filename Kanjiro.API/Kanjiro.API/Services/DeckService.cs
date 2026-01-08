using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils.Enums;
using Kanjiro.API.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Services
{
    public class DeckService : IDeckService
    {
        private Kanjiro_Context _context;

        public DeckService(Kanjiro_Context context)
        {
            _context = context;
        }

        public async Task<CardInfo> ShowCardToReview(int DeckId)
        {
            var cardToReview = await _context.Cards.Include(x => x.Info).AsNoTracking().FirstOrDefaultAsync(x => x.NextReviewDate.Date < DateTime.UtcNow && x.State != CardState.FLAGGED && x.DeckId == DeckId);

            if (cardToReview == null) throw new KanjiroCustomException("Nenhuma carta encontrada para revisar.");

            return cardToReview.Info;
        }

        public async Task<Deck> AddDeck(string deckName, int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null) throw new KanjiroCustomException("Usuário não encontrado.");
            var newDeck = new Deck { Name = deckName, UserId = user.Id };

            await _context.Decks.AddAsync(newDeck);

            return newDeck;
        }

        public async Task<Card> AddCardToDeck(int cardInfoId, int deckId)
        {
            var cardInfo = await _context.CardInfos.FirstOrDefaultAsync(x => x.Id == cardInfoId);

            if (cardInfo == null) throw new KanjiroCustomException("Não foi possível encontrar a carta escolhida.");

            var DeckToAdd = await _context.Decks.FirstOrDefaultAsync(y => y.Id == deckId);

            if (DeckToAdd == null) throw new KanjiroCustomException("Não foi possível encontrar o deck escolhido.");

            var cardToAdd = new Card(cardInfo, DeckToAdd.Id);

            await _context.Cards.AddAsync(cardToAdd);

            return cardToAdd;
        }

        public async Task AddNextCardsToLearn(int deckId)
        {
            var deck = await _context.Decks.Include(x => x.Cards).ThenInclude(x => x.Info).FirstOrDefaultAsync(x => x.Id == deckId);
            if (deck == null) throw new KanjiroCustomException("Não foi possível encontrar o Deck");

            var newKanjis = _context.CardInfos.Where(x => !deck.Cards.Any(y => y.Info.Id == x.Id)).Take(10).ToList();
            var newCards = new List<Card>();

            foreach (var kanjiInfo in newKanjis)
            {
                var card = new Card(kanjiInfo, deckId);

                newCards.Add(card);
            }

            deck.Cards.AddRange(newCards);
        }

        public async Task<List<CardInfo>> GetNextCardsToLearn(Deck deck)
        {
            return new List<CardInfo>();
        }

    }
}
