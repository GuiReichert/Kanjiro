using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardInfo_Controller : ControllerBase
    {
        private readonly Kanjiro_Context _context;

        public CardInfo_Controller(Kanjiro_Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CardInfo>>> AddCard(CardInfo cardInfo)
        {
            return Ok(cardInfo);
        }
    }
}
