using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.Users.Queries.GetById.DTOs;

namespace CleanArchitecture.Template.Application.Users.Queries.GetById
{
    public record GetUserByIdQuery(Guid Id) : IQuery<GetUserByIdResponse> { }
}
