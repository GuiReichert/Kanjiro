using Kanjiro.API.Database;
using Kanjiro.API.Models.DTO_s;
using Kanjiro.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Services
{
    public class UserService : IUserService
    {
        private Kanjiro_Context _context;

        public UserService(Kanjiro_Context context)
        {
            _context = context;
        }

        public async Task SynchronizeChanges(UserDTO user)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (currentUser == null) throw new Exception("Não foi possível encontrar a conta para sincronizar");

            currentUser.Settings = user.Settings;
            currentUser.Decks = user.Decks;
        }
    }
}
