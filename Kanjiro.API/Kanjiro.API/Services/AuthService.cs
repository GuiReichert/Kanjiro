using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;

namespace Kanjiro.API.Services
{
    public class AuthService : IAuthService
    {
        private Kanjiro_Context _context;
        private ITokenService _tokenService;

        public AuthService(Kanjiro_Context context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string> Register(string username, string password)
        {
            return "";
        }

        public async Task<string> Login(string username, string password)
        {
            return "";
        }


    }
}
