using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShgEcom.Application.Common.Interfaces.Authentication;
using ShgEcom.Application.Common.Interfaces.Services;
using ShgEcom.Domain.Entites;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShgEcom.Infrastructure.Authentication
{
    public class JwtTokenGeneratore(IDateTimeProvider _dateTimeProvider, IOptions<JwtSettings> jwtOptions) : IJwtTokenGenerator
    {
        public string GenerateToken(User user)
        {
            var siginingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Secret)), SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: jwtOptions.Value.Issuer,
                expires: _dateTimeProvider.UtcNow.AddMinutes(jwtOptions.Value.ExpiryMinutes),
                claims: claims,
                audience: jwtOptions.Value.Audience,
                signingCredentials: siginingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
