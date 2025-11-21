using Kanjiro.API.Enums;

namespace Kanjiro.API.Models.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserAccountType AccountType { get; set; }
        public List<Deck> Decks { get; set; } = new List<Deck>();
        public UserSettings Settings { get; set; } = new UserSettings();

    }
}
