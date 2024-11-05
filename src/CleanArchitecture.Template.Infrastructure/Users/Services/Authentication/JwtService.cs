using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.SharedKernel.Options.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public LoginUserResponse GenerateToken(User user)
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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expirationDate = DateTime.UtcNow.AddDays(_jwtSettings.ExpirationDateInDays);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expirationDate,
                signingCredentials: creds);

            return new LoginUserResponse(new JwtSecurityTokenHandler().WriteToken(token), expirationDate);
        }
    }
}