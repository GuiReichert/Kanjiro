using Kanjiro.API.Models.DTO_s;
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
        private IUserService _userService;

        public UserController(IAuthService authService, IUnitOfWork unitOfWork, IUserService userService)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        #region "Endpoints"


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

            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<UserDTO>>> Login([FromBody] LoginRequestModel loginRequest)
        {
            var response = new ServiceResponse<UserDTO>();

            try
            {
                var userData = await _authService.Login(loginRequest.Username, loginRequest.Password);

                response.ReturnData = userData;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            if (response.Success) return Ok(response);
            return BadRequest(response);

        }

        [HttpPut("Synchronize")]
        public async Task<ActionResult<ServiceResponse<UserDTO>>> SynchronizeChanges([FromBody] UserDTO user)
        {
            //TODO: Validar usuário e senha novamente ou token / refreshToken

            var response = new ServiceResponse<UserDTO>();

            try
            {
                var userData = await _userService.SynchronizeChanges(user);
                response.ReturnData = userData;
                await _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            if (response.Success) return Ok(response);
            return BadRequest(response);

        }

        #endregion

        #region "Private Models"

        public class LoginRequestModel
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        #endregion
    }
}
