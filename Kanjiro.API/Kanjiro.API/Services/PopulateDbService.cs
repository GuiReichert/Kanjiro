using Kanjiro.API.Enums;
using System.Text.Json;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Models.PopulateModel;

namespace Kanjiro.API.Services
{
    public class PopulateDbService
    {
        public List<CardInfo> PopulateCards()
        {
            string path = @"C:\Users\GTXRo\Desktop\KanjiAPI_Data\kanjiapi_full.json";

            var arquivo_txt = System.IO.File.ReadAllText(path);

            KanjiRoot root = JsonSerializer.Deserialize<KanjiRoot>(arquivo_txt);

            var cards = root.Kanjis.Values.Where(x => x.Jlpt == 5 || x.Jlpt == 4 || x.Jlpt == 3 || x.Jlpt == 2|| x.Jlpt == 1).Select(k => new CardInfo()
            {
                Front = k.Kanji,
                Back = string.Join(",", k.OnReadings.Concat(k.KunReadings)),
                Level = (JLPT_Level)k.Jlpt
            }).ToList();

            return cards;
        }

    }
}
