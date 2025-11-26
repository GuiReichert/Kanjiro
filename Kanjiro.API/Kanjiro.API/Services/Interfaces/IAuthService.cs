using Kanjiro.API.Models.DTO_s;

namespace Kanjiro.API.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> Register(string username, string password);
        public Task<UserDTO> Login(string username, string password);
    }
}
