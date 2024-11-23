using CleanArchitecture.Template.Application.Users.Repositories;
using CleanArchitecture.Template.Application.Users.Services;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Specifications;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CleanArchitecture.Template.Infrastructure.Users.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public Guid? UserId
        {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                return userIdClaim != null ? Guid.Parse(userIdClaim) : (Guid?)null;
            }
        }

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public async Task<User?> GetCurrentUserAsync()
        {
            return UserId is not null
                ? await _userRepository.GetBySpecificationAsync(new UserByIdSpecification(UserId.Value))
                : null;
        }
    }
}
