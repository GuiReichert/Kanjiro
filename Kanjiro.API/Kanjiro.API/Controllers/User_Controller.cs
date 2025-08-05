using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User_Controller : ControllerBase
    {
        private IUserService _userService;
        private IUnitOfWork _unitOfWork;

        public User_Controller(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<User>>> PostUser(string userName)
        {
            var response = new ServiceResponse<User>();

            try
            {
                var user = await _userService.CreateUser(userName);
                await _unitOfWork.SaveChanges();

                response.ReturnData = user;
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
