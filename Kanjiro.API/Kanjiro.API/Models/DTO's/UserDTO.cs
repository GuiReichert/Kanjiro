using Kanjiro.API.Enums;
using Kanjiro.API.Models.Model;

namespace Kanjiro.API.Models.DTO_s
{
    public class UserDTO
    {
        // Auth,Refresh Token????
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public DateTime? LastSyncDate { get; set; }
        public List<Deck> Decks { get; set; } = new List<Deck>();
        public UserAccountType AccountType { get; set; }
        public UserSettings Settings { get; set; } = new UserSettings();
    }
}
