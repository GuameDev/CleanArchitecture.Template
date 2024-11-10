using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.Permissions;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.SharedKernel.Options.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Template.Infrastructure.Users.Services.Authentication
{
    public class JwtService : IAuthTokenService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public LoginUserTokenResponse GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username.Value),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email.Value),
        };

            // Add roles as claims
            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.RoleName.ToString())));

            // Add permissions as claims
            var permissions = user.Roles.SelectMany(role => role.Permissions).Distinct();
            claims.AddRange(permissions.Select(permission => new Claim(nameof(Permission), permission.Type.ToString())));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.AccessToken.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expirationDate = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessToken.ExpirationDateInMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.AccessToken.Issuer,
                audience: _jwtSettings.AccessToken.Audience,
                claims: claims,
                expires: expirationDate,
                signingCredentials: creds);

            return new LoginUserTokenResponse(new JwtSecurityTokenHandler().WriteToken(token), expirationDate);
        }

        public LoginUserTokenResponse GenerateRefreshToken()
        {
            var tokenBytes = new byte[RefreshTokenConstants.TokenMinLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(tokenBytes);
            }
            var token = Convert.ToBase64String(tokenBytes);
            var expirationDate = DateTime.UtcNow.AddDays(_jwtSettings.RefreshToken.ExpirationDateInDays);
            return new LoginUserTokenResponse(token, expirationDate);
        }
    }
}