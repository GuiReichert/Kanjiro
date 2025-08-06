using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("Deck/Card")]
    public class Card_Controller : ControllerBase
    {
        private IDeckService _deckService;
        private IUnitOfWork _unitOfWork;

        public Card_Controller(IDeckService deckService, IUnitOfWork unitOfWork)
        {
            _deckService = deckService;
            _unitOfWork = unitOfWork;
        }


        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<Card>>> PostCardToDeck(int cardInfoId, int deckId)
        {
            var response = new ServiceResponse<Card>();
            try
            {
                var card = await _deckService.AddCardToDeck(cardInfoId, deckId);
                await _unitOfWork.SaveChanges();


                response.ReturnData = card;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            if (response.Success) Ok(response);
            return BadRequest(response);

        }
    }
}
