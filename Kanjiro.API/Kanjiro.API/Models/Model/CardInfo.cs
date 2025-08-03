using Kanjiro.API.Enums;

namespace Kanjiro.API.Models.Model
{
    public class CardInfo
    {
        public int Id { get; set; }
        public JLPT_Level Level { get; set; }

        public string Front { get; set; } = string.Empty;
        public string Back { get; set; } = string.Empty;

        public string Kanji { get; set; } = string.Empty ;
        public List<string> Readings = new List<string>() ;
        public List<string> Example_Words = new List<string>() ;
        public string AdditionalInfo { get; set; } = string.Empty;

    }
}
