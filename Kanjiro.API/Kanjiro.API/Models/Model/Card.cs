using Kanjiro.API.Enums;

namespace Kanjiro.API.Models.Model
{
    public class Card
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public CardInfo Info { get; set; } = new CardInfo();
        public CardState State { get; set; }
        public DateTime NextReviewDate { get; set; }
        public int MistakeCounter {  get; set; }
        public float CurrentDifficultyMultiplier { get; set; }
        public int ReviewDateCounter {  get; set; }

    }
}
