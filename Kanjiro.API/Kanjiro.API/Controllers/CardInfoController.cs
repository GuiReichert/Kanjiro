using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils;
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
            return await KanjiroApiController.Execute(async () =>
            {
                return await _cardInfoService.GetCardInfoById(id);
            });
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CardInfo>>>> SearchKanjiByText([FromQuery] string? text)
        {
            return await KanjiroApiController.Execute(async () =>
            {
                return await _cardInfoService.GetMultipleCardInfosByText(text);
            });
        }

        #endregion
    }
}
