using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils.Enums;
using Kanjiro.API.Utils.Exceptions;
using Kanjiro.API.Utils.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacementTestController : ControllerBase
    {
        private IPlacementTestService _placementTestService;
        private IUnitOfWork _unitOfWork;

        public PlacementTestController(IPlacementTestService placementTestService, IUnitOfWork unitOfWork)
        {
            _placementTestService = placementTestService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<ServiceResponse<List<CardInfo>>>> GetProvaNivelamentoPorNivel()
        {
            return await KanjiroApiController.HandleRequest<List<CardInfo>>(async () =>
            {
                return await _placementTestService.GetPlacementTestCardsByLevel();
            });
        }


        [HttpPost("results")]
        public async Task<ActionResult<ServiceResponse<Deck>>> PostPlacementTestResults(int userId, int level, int correctAnswers)
        {
            var result = await KanjiroApiController.HandleRequest<Deck>(async () =>
            {
                if (!Enum.IsDefined(typeof(JLPT_Level), level) || !Enum.TryParse<JLPT_Level>(level.ToString(), out var parsedLevel)) throw new KanjiroCustomException("Não foi possível reconhecer o nível JLPT.");
                return await _placementTestService.GetPlacementTestResults(userId, parsedLevel, correctAnswers);
            });
            await _unitOfWork.SaveChanges();

            return result;
        }

    }
}
