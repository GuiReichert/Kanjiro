using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Services
{
    public class CardInfoService
    {
        private Kanjiro_Context _context;

        public CardInfoService(Kanjiro_Context context)
        {
            _context = context;
        }

        public async Task<CardInfo> GetCardInfoById(int Id)
        {
            var cardInfo = await _context.CardInfos.FirstOrDefaultAsync(x => x.Id == Id);

            if (cardInfo == null) throw new Exception("Não foi possível encontrar nenhum kanji com este Id.");

            return cardInfo;
        }
    }
}
