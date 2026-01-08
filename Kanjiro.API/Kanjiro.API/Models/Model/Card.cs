using Kanjiro.API.Utils.Enums;

namespace Kanjiro.API.Models.Model
{
    public class Card
    {

        protected Card() { }
        public Card(CardInfo Info, int DeckId, CardState cardState = CardState.NEW)
        {
            this.DeckId = DeckId;
            this.Info = Info;
            State = cardState;
        }

        public int Id { get; set; }
        public int DeckId { get; set; }
        public CardInfo Info { get; set; } = new CardInfo();        // TODO: Retirar esta referência: sempre que alterar uma carta, acabará alterando essas informações que devem ser estáticas.
        public CardState State { get; set; } = CardState.NEW;
        public DateTime NextReviewDate { get; set; } = DateTime.UtcNow;
        public int MistakeCounter { get; set; } = 0;
        public float CurrentDifficultyMultiplier { get; set; } = 1;
        public int ReviewDateCounter { get; set; } = 1;
        public string UserComment { get; set; } = string.Empty;

    }
}
