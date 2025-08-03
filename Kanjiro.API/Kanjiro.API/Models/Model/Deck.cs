namespace Kanjiro.API.Models.Model
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Card> Cards { get; set; } = new List<Card>();
        public User User { get; set; } = new User();
        
    }
}
