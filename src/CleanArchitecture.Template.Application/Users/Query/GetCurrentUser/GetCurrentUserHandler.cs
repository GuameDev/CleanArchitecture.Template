using CleanArchitecture.Template.Application.Users.Query.GetCurrentUser.DTOs;
using CleanArchitecture.Template.Application.Users.Services;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.Users.Query.GetCurrentUser
{
    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, Result<GetCurrentUserResponse>>
    {
        private readonly ICurrentUserService _currentUserService;

        public GetCurrentUserHandler(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<Result<GetCurrentUserResponse>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUserService.GetCurrentUserAsync();

            if (currentUser is null)
                return Result.Failure<GetCurrentUserResponse>(UserErrors.UserNotFound);

            return Result.Success(new GetCurrentUserResponse(
                currentUser.Id,
                currentUser.Username.Value,
                currentUser.Email.Value,
                currentUser.FullName.FirstName,
                currentUser.FullName.LastName1,
                currentUser.FullName.LastName2,
                currentUser.IsActive)
            {
                Roles = currentUser.Roles.Select(x => x.RoleName.ToString()),
                Permissions = currentUser.Roles.SelectMany(x => x.Permissions).Select(x => x.Type.ToString())
            });
        }
    }
}
