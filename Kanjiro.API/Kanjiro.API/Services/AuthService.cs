using System.Security.Cryptography;
using System.Text;
using Kanjiro.API.Database;
using Kanjiro.API.Models.DTO_s;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            if (_context.Users.Any(x => x.UserName.ToLower() == username.ToLower())) throw new Exception("This Username is already in use.");

            // Adicionar validação para senhas com regex

            EncryptPassword(password, out var passwordHash, out var passwordSalt);

            var newUser = new User
            {
                UserName = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Decks = new List<Deck>(),
                AccountType = Enums.UserAccountType.Normal,
                Settings = new UserSettings()
            };

            await _context.Users.AddAsync(newUser);

            return "Account created successfully.";
        }

        public async Task<UserDTO> Login(string username, string password)
        {
            var user = await _context.Users.Include(x => x.Decks).ThenInclude(x => x.Cards).ThenInclude(x => x.Info).Include(x => x.Settings).FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null || !ValidatePassword(username, password, user)) throw new Exception("Username or password incorrect.");

            var ValidationToken = _tokenService.CreateValidationJWT(user);

            var userDTO = new UserDTO           // TODO: Eventualmente alterar para Mapper
            {
                UserName = user.UserName,
                AccountType = user.AccountType,
                Decks = user.Decks,
                Settings = user.Settings,
            };

            return userDTO;
        }

        #region Private Functions
        private void EncryptPassword(string userPassword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA3_512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userPassword));
            }
        }

        private bool ValidatePassword(string username, string password, User storedUser)
        {
            using (var hmac = new HMACSHA3_512(storedUser.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(storedUser.PasswordHash);

            }
        }

        #endregion

    }
}
