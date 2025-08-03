using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Services
{
    public class DeckService
    {
        private Kanjiro_Context _context;

        public DeckService(Kanjiro_Context context)
        {
            _context = context;
        }

        public async Task<CardInfo> ShowCardToReview(int DeckId)
        {
            var cardToReview = await _context.Cards.FirstOrDefaultAsync(x => x.ReviewSchedule.Date < DateTime.Now && x.State != Enums.CardState.Flagged); // DeckId == x.DeckId
            
            if (cardToReview == null ) throw new Exception("Nenhuma carta encontrada para revisar.");

            return cardToReview.Info;
        }

        public async Task AddDeck(string deckName)
        {
            var newDeck = new Deck { Name = deckName };

            await _context.AddAsync(newDeck);
        }

        public async Task AddCardToDeck(int cardInfoId, int deckId)
        {
            var cardInfo = await _context.CardInfos.FirstOrDefaultAsync(x => x.Id == cardInfoId);

            if (cardInfo == null) throw new Exception("Não foi possível encontrar a carta escolhida.");

            var DeckToAdd = await _context.Decks.FirstOrDefaultAsync(y => y.Id == deckId);

            if (DeckToAdd == null) throw new Exception("Não foi possível encontrar o deck escolhido.");

            var cardToAdd = new Card {
                Info = cardInfo,
                ReviewSchedule = DateTime.Now,
                State = Enums.CardState.New,
                Deck = DeckToAdd
                };
                
            await _context.AddAsync(cardToAdd);
        }

    }
}
