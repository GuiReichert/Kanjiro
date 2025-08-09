namespace Kanjiro.API.Models.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public List<Deck> Decks { get; set; } = new List<Deck>();

    }
}
