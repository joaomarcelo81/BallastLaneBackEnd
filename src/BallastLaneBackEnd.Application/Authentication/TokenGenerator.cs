using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using System.Text.Json;
using BallastLaneBackEnd.Domain.Authentication;

namespace BallastLaneBackEnd.Api.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        private const string INPUTKEY = "A094F7D2-A244-49C6-8ADA-D1771757516Z";

        public dynamic Generator(string login)
        {
            var claims = new List<Claim>
            {
                new Claim("User", login)
            };

            var expires = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(INPUTKEY));
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims);


            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new
            {
                acess_token = token,
                expirations = expires
            };

        }
    }
}
