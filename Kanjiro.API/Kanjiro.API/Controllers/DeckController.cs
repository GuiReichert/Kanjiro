using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

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
            var response = new ServiceResponse<CardInfo>();

            try
            {
                var cardInfo = await _deckService.ShowCardToReview(deckId);

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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Deck>>> PostDeck(int userId, string deckName)
        {
            var response = new ServiceResponse<Deck>();

            try
            {
                var deck = await _deckService.AddDeck(deckName, userId);
                await _unitOfWork.SaveChanges();

                response.ReturnData = deck;
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
