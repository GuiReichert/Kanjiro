using Kanjiro.API.Utils.Enums;

namespace Kanjiro.API.Models.Model
{
    public class Card
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public CardInfo Info { get; set; } = new CardInfo();        // TODO: Retirar esta referência: sempre que alterar uma carta, acabará alterando essas informações que devem ser estáticas.
        public CardState State { get; set; }
        public DateTime NextReviewDate { get; set; }
        public int MistakeCounter { get; set; }
        public float CurrentDifficultyMultiplier { get; set; } = 1;
        public int ReviewDateCounter { get; set; } = 1;
        public string UserComment { get; set; } = string.Empty;

    }
}
