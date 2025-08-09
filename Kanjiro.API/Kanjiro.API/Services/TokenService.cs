using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Services.Interfaces;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Kanjiro.API.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JWTSecurityKey").ToString()!);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var descriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(8),
                Subject = GenerateClaims(user)
            };


            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }



        private static ClaimsIdentity GenerateClaims(User user)
        {
            var CI = new ClaimsIdentity();
            CI.AddClaim(new Claim(type: ClaimTypes.NameIdentifier, value: user.Id.ToString()));
            CI.AddClaim(new Claim(type: ClaimTypes.Name, value: user.UserName));
            CI.AddClaim(new Claim(type: ClaimTypes.Role, value: user.AccountType.ToString()));

            return CI;
        }
    }
}
