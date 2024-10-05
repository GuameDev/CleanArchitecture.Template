using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.Base.Messaging
{
    public interface ICommand : IRequest<Result>
    {

    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
