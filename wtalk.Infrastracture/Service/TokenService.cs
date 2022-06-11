using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Interfaces;

namespace Wtalk.Infrastracture.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        public string CreateToken(int userId, int companyId, string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim("UserId", userId.ToString()),
                new Claim("CompanyId", companyId.ToString()),


            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<Claim> ReadToken(string token)
        {
            var jwt = "";
            jwt = token["Bearer ".Length..];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(jwt);
            return jwtSecurityToken.Claims;
        }

        public int ReadCompanyId(string token)
        {
            var claims = ReadToken(token);
            return Convert.ToInt32(claims.First(x => x.Type == "CompanyId").Value);
        }

        public int ReadUserId(string token)
        {
            var claims = ReadToken(token);
            return Convert.ToInt32(claims.First(x => x.Type == "UserId").Value);
        }
    }
}
