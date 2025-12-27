using System.Security.Cryptography;
using System.Text;
using Kanjiro.API.Database;
using Kanjiro.API.Models.DTO_s;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils.Enums;
using Kanjiro.API.Utils.Exceptions;
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

        public async Task<string> Register(string username, string password)    // TODO: Passar Register e Login para UserService e UserController
        {

            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (_context.Users.Any(x => x.UserName.ToLower() == username.ToLower())) throw new KanjiroCustomException("This Username is already in use.");

                    // Adicionar validação para senhas com regex

                    EncryptPassword(password, out var passwordHash, out var passwordSalt);

                    var newUser = new User
                    {
                        UserName = username,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        AccountType = UserAccountType.NORMAL,
                        Settings = new UserSettings()
                    };

                    var newDeck = new Deck() { Name = "Initial Deck" };
                    newUser.Decks = new List<Deck> { newDeck };

                    await _context.Users.AddAsync(newUser);
                    await _context.SaveChangesAsync();

                    newUser.CurrentActiveDeckId = newDeck.Id;
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();


                    return "Account created successfully.";
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

        }

        public async Task<UserDTO> Login(string username, string password)
        {
            var user = await _context.Users.Include(x => x.Decks).ThenInclude(x => x.Cards).ThenInclude(x => x.Info).Include(x => x.Settings).AsNoTracking().FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null || !ValidatePassword(username, password, user)) throw new KanjiroCustomException("Username or password incorrect.");

            var ValidationToken = _tokenService.CreateValidationJWT(user);

            //TODO: Sincronizar / adicionar cartas ao logar?


            var currentDeck = user.Decks.Where(x => x.Id == user.CurrentActiveDeckId).ToList(); //TODO: Ajustar o retorno (lista ou valor singular). Também arrumar no APP

            if (!currentDeck.Any()) currentDeck = user.Decks;

            var userDTO = new UserDTO           // TODO: Eventualmente alterar para Mapper
            {
                Id = user.Id,
                UserName = user.UserName,
                AccountType = user.AccountType,
                Decks = currentDeck,
                Settings = user.Settings,
                LastSyncDate = user.LastSyncDate,
                NickName = user.NickName,
                currentActiveDeckId = user.CurrentActiveDeckId,
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
