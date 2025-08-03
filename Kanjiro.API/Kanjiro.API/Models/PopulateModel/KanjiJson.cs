using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Kanjiro.API.Models.PopulateModel
{
    public class KanjiRoot
    {
        [JsonPropertyName("kanjis")]
        public Dictionary<string, KanjiJson> Kanjis { get; set; }
    }

    public class KanjiJson
    {
        [JsonPropertyName("freq_mainichi_shinbun")]
        public int? FreqMainichiShinbun { get; set; }

        [JsonPropertyName("grade")]
        public int? Grade { get; set; }

        [JsonPropertyName("heisig_en")]
        public string HeisigEn { get; set; }

        [JsonPropertyName("jlpt")]
        public int? Jlpt { get; set; }

        [JsonPropertyName("kanji")]
        public string Kanji { get; set; }

        [JsonPropertyName("kun_readings")]
        public List<string> KunReadings { get; set; }

        [JsonPropertyName("meanings")]
        public List<string> Meanings { get; set; }

        [JsonPropertyName("name_readings")]
        public List<string> NameReadings { get; set; }

        [JsonPropertyName("notes")]
        public List<string> Notes { get; set; }

        [JsonPropertyName("on_readings")]
        public List<string> OnReadings { get; set; }

        [JsonPropertyName("stroke_count")]
        public int StrokeCount { get; set; }

        [JsonPropertyName("unicode")]
        public string Unicode { get; set; }
    }
}

