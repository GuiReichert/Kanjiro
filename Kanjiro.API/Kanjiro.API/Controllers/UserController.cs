using Kanjiro.API.Models.DTO_s;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils;
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
            return await KanjiroApiController.Execute(async () =>
            {
                var data = await _authService.Register(Username, Password);
                await _unitOfWork.SaveChanges();

                return data;
            });
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<UserDTO>>> Login([FromBody] LoginRequestModel loginRequest)
        {
            return await KanjiroApiController.Execute(async () =>
            {
                return await _authService.Login(loginRequest.Username, loginRequest.Password);
            });
        }

        [HttpPut("Synchronize")]
        public async Task<ActionResult<ServiceResponse<UserDTO>>> SynchronizeChanges([FromBody] UserDTO user)
        {
            //TODO: Validar usuário e senha novamente ou token / refreshToken

            return await KanjiroApiController.Execute(async () =>
            {
                var userData = await _userService.SynchronizeChanges(user);
                await _unitOfWork.SaveChanges();

                return userData;
            });
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
