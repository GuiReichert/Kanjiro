using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("Deck")]
    public class DeckController : ControllerBase
    {
        private IDeckService _deckService;
        private IUnitOfWork _unitOfWork;

        public DeckController(IDeckService deckService, IUnitOfWork unitOfWork)
        {
            _deckService = deckService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Review")]
        public async Task<ActionResult<ServiceResponse<CardInfo>>> GetReviewCard(int deckId)
        {
            return await KanjiroApiController.HandleRequest(async () =>
            {
                return await _deckService.ShowCardToReview(deckId);
            });
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Deck>>> PostDeck(int userId, string deckName)
        {
            return await KanjiroApiController.HandleRequest(async () =>
            {
                var deck = await _deckService.AddDeck(deckName, userId);
                await _unitOfWork.SaveChanges();

                return deck;
            });
        }
    }
}
