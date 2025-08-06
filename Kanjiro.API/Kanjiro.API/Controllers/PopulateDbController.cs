using Kanjiro.API.Database;
using Kanjiro.API.Enums;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Models.PopulateModel;
using Kanjiro.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            var data = new ServiceResponse<string>();
            try
            {

                var Kanjis_N5 = _populateService.PopulateCards();

                await _context.CardInfos.AddRangeAsync(Kanjis_N5);
                await _context.SaveChangesAsync();

                data.ReturnData = "dados salvos com sucesso";
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.Message = ex.Message;
                data.ReturnData = ex.Message;

                return BadRequest(data);
            }

            if (!data.Success) return BadRequest(data);
            return Ok(data);
        }

    }
}
