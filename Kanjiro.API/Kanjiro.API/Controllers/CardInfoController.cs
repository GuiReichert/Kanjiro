using Kanjiro.API.Models.Model;
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

        #region "Search"

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CardInfo>>> SearchKanjiById(int id)
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

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CardInfo>>>> SearchKanjiByText([FromQuery] string? text)
        {
            var response = new ServiceResponse<List<CardInfo>>();

            try
            {
                var cardInfos = await _cardInfoService.GetMultipleCardInfosByText(text);

                response.ReturnData = cardInfos;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        #endregion
    }
}
