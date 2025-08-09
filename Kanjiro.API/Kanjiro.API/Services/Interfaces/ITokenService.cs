using Kanjiro.API.Models.Model;

namespace Kanjiro.API.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateValidationJWT(User user);
    }
}
