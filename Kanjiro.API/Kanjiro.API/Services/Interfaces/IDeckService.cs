using Kanjiro.API.Models.Model;

namespace Kanjiro.API.Services.Interfaces
{
    public interface IDeckService
    {
        public Task<CardInfo> ShowCardToReview(int DeckId);
        public Task<Deck> AddDeck(string deckName, int userId);
        public Task<Card> AddCardToDeck(int cardInfoId, int deckId);

    }
}
