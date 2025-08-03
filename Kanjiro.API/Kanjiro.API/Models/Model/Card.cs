using Kanjiro.API.Enums;

namespace Kanjiro.API.Models.Model
{
    public class Card
    {
        public int Id { get; set; }
        public CardInfo Info { get; set; } = new CardInfo();
        public CardState State { get; set; }
        public DateTime ReviewSchedule { get; set; }
        public Deck Deck { get; set; } = new Deck();

    }
}
