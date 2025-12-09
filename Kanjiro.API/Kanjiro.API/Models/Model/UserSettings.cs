namespace Kanjiro.API.Models.Model
{
    public class UserSettings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool darkMode { get; set; }
        public bool allowNotifications { get; set; }
    }
}
