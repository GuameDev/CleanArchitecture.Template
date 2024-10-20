using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.Users.Query.GetById.DTOs;

namespace CleanArchitecture.Template.Application.Users.Query.GetById
{
    public record GetUserByIdQuery(Guid Id) : IQuery<GetUserByIdResponse> { }
}
