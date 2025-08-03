using Kanjiro.API.Enums;

namespace Kanjiro.API.Models.Model
{
    public class CardInfo
    {
        public int Id { get; set; }
        public JLPT_Level Level { get; set; }

        public string Front { get; set; } = string.Empty;
        public string Back { get; set; } = string.Empty;
        public string AdditionalInfo { get; set; } = string.Empty;

    }
}
