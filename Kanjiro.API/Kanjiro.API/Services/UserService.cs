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

        public async Task<User> CreateUser(string userName)
        {
            var user = new User() {UserName = userName };

            await _context.Users.AddAsync(user);

            return user;
        }
    }
}
