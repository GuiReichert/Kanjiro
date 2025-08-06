using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services;
using Kanjiro.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardInfoController : ControllerBase
    {
        private ICardInfoService _cardInfoService;

        public CardInfoController(ICardInfoService cardInfoService)
        {
            _cardInfoService = cardInfoService;
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
