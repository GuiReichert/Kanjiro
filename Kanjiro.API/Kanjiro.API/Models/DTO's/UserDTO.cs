using Kanjiro.API.Models.Model;
using Kanjiro.API.Utils.Enums;

namespace Kanjiro.API.Models.DTO_s
{
    public class UserDTO
    {
        // Auth,Refresh Token????
        #region Properties
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public DateTime? LastSyncDate { get; set; }
        public List<Deck> Decks { get; set; } = new List<Deck>();
        public UserAccountType AccountType { get; set; }
        public UserSettings Settings { get; set; } = new UserSettings();
        public int currentActiveDeckId { get; set; }

        #endregion

        #region Mappers

        public static UserDTO FromUser(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                AccountType = user.AccountType,
                currentActiveDeckId = user.CurrentActiveDeckId,
                Decks = user.Decks,
                LastSyncDate = user.LastSyncDate,
                Settings = user.Settings,
                NickName = user.NickName
            };
        }

        #endregion
    }
}
