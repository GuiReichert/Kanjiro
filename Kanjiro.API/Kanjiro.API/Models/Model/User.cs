using Kanjiro.API.Utils.Enums;

namespace Kanjiro.API.Models.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? LastSyncDate { get; set; }
        public UserAccountType AccountType { get; set; }
        public List<Deck> Decks { get; set; } = new List<Deck>();
        public int CurrentActiveDeckId { get; set; }
        public UserSettings Settings { get; set; } = new UserSettings();

    }
}
