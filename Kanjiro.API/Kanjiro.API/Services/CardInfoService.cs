using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Services
{
    public class CardInfoService : ICardInfoService
    {
        private Kanjiro_Context _context;

        public CardInfoService(Kanjiro_Context context)
        {
            _context = context;
        }

        public async Task<CardInfo> GetCardInfoById(int Id)
        {
            var cardInfo = await _context.CardInfos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);

            if (cardInfo == null) throw new KanjiroCustomException("Não foi possível encontrar nenhum kanji com este Id.");

            return cardInfo;
        }

        public async Task<List<CardInfo>> GetMultipleCardInfosByText(string? text)
        {
            if (string.IsNullOrWhiteSpace(text)) return new List<CardInfo>();

            var cardInfos = await _context.CardInfos.Where(x => x.Front.Contains(text) || x.Back.Contains(text) || x.RomajiReading.ToLower().Contains(text.ToLower())).AsNoTracking().ToListAsync();

            return cardInfos;
        }

    }
}
