using Kanjiro.API.Enums;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils;
using Kanjiro.API.Utils.Exceptions;
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

        [HttpGet("{level}")]
        public async Task<ActionResult<ServiceResponse<List<CardInfo>>>> GetProvaNivelamentoPorNivel(int level)
        {
            return await KanjiroApiController.HandleRequest<List<CardInfo>>(async () =>
            {
                //TODO: Verificar se é melhor fazer um GET por nível ou apenas um GET que envia todas as cartas de uma vez.
                if (!Enum.IsDefined(typeof(JLPT_Level), level) || !Enum.TryParse<JLPT_Level>(level.ToString(), out var result)) throw new KanjiroCustomException("Não foi possível reconhecer o nível JLPT.");

                return await _placementTestService.GetPlacementTestCardsByLevel(result);
            });
        }


        [HttpPost("results")]
        public async Task<ActionResult<ServiceResponse<Deck>>> PostPlacementTestResults(int userId, int correctAnswers)
        {
            var result = await KanjiroApiController.HandleRequest<Deck>(async () => { return await _placementTestService.GetPlacementTestResults(userId, correctAnswers); });
            await _unitOfWork.SaveChanges();

            return result;
        }

    }
}
