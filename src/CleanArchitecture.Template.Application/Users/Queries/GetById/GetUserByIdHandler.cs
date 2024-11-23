using CleanArchitecture.Template.Application.Users.Queries.GetById.DTOs;
using CleanArchitecture.Template.Application.Users.Repositories;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Specifications;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.Users.Queries.GetById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<GetUserByIdResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new UserByIdSpecification(request.Id);
            var entity = await _userRepository.GetBySpecificationAsync(specification);

            if (entity is null)
                return Result.Failure<GetUserByIdResponse>(UserErrors.UserAlreadyExist);

            return Result.Success(new GetUserByIdResponse(
                entity.Id,
                entity.Username.Value,
                entity.Email.Value,
                entity.FullName.FirstName,
                entity.FullName.LastName1,
                entity.FullName.LastName2,
                entity.IsActive)
            {
                Roles = entity.Roles.Select(x => x.RoleName.ToString()),
                Permissions = entity.Roles.SelectMany(x => x.Permissions).Select(x => x.Type.ToString())
            });

        }
    }
}
