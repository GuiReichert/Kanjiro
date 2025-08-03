namespace Kanjiro.API.Models.Model
{
    public class CardInfo
    {
        public int Id { get; set; }

        public string Front { get; set; } = string.Empty;
        public string Back { get; set; } = string.Empty;
        public string AdditionalInfo { get; set; } = string.Empty;

    }
}
