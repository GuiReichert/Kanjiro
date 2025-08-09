using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IAuthService _authService;
        private IUnitOfWork _unitOfWork;

        public UserController(IAuthService authService, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<string>>> RegisterUser(string Username, string Password)
        {
            var response = new ServiceResponse<string>();

            try
            {
                var data = await _authService.Register(Username, Password);
                await _unitOfWork.SaveChanges();

                response.ReturnData = data;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            if(response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(string Username, string Password)
        {
            var response = new ServiceResponse<string>();

            try
            {
                var ValidationToken = await _authService.Login(Username, Password);

                response.ReturnData = ValidationToken;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            if (response.Success) return Ok(response);
            return BadRequest(response);

        }



    }
}
