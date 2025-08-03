using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardInfo_Controller : ControllerBase
    {
        private readonly Kanjiro_Context _context;
        CardInfoService _cardInfoService;

        public CardInfo_Controller(Kanjiro_Context context)
        {
            _context = context;
            if (_cardInfoService == null) _cardInfoService = new CardInfoService(context);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CardInfo>>> AddCard(CardInfo cardInfo)
        {
            return Ok(cardInfo);
        }

        [HttpGet("KanjiInfo")]
        public async Task<ActionResult<ServiceResponse<CardInfo>>> GetKanjiInfo(int id)
        {
            var response = new ServiceResponse<CardInfo>();

            try
            {
                var cardInfo = await _cardInfoService.GetCardInfoById(id);

                response.ReturnData = cardInfo;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}
