using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;

namespace Kanjiro.API.Services
{
    public class UserService : IUserService
    {
        private Kanjiro_Context _context;

        public UserService(Kanjiro_Context context)
        {
            _context = context;
        }

    }
}
