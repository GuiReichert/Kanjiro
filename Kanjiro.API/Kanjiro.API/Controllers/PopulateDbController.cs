using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services;
using Kanjiro.API.Utils.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PopulateDbController : ControllerBase
    {
        private Kanjiro_Context _context;
        private PopulateDbService _populateService = new PopulateDbService();

        public PopulateDbController(Kanjiro_Context context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult<ServiceResponse<string>>> PopulateAPI()
        {
            return await KanjiroApiController.HandleRequest(async () =>
            {
                var Kanjis = _populateService.PopulateCards();

                await _context.CardInfos.AddRangeAsync(Kanjis);
                await _context.SaveChangesAsync();

                return "Banco de dados populado com sucesso.";

            });
        }

    }
}
