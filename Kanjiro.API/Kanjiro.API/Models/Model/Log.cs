using Kanjiro.API.Enums;

namespace Kanjiro.API.Models.Model
{
    public class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public LogOrigin Origin { get; set; }
        public LogType Type { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
