using CleanArchitecture.Template.Api.Constants;
using CleanArchitecture.Template.Api.Results;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser.DTOs;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.Api.Controllers
{
    [ApiController]
    [Route("auth")]

    public class AuthenticationController : ControllerBase
    {

        private readonly ISender _sender;

        public AuthenticationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var command = new RegisterUserCommand(request.Username, request.Email, request.FirstName, request.LastName1, request.LastName2, request.Password);
            var result = await _sender.Send(command);

            return result.Match(
                onSuccess: () => CreatedAtAction(
                    actionName: nameof(UserController.GetById),
                    controllerName: RoutesConstants.UserControllerRoute,
                    routeValues: new { id = result.Value.Id },
                    value: result.Value),
                onFailure: ApiResults.Problem
            );
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest request)
        {
            var command = new LoginUserCommand(request.UsernameOrEmail, request.Password);
            var result = await _sender.Send(command);

            return result.Match(
                onSuccess: Ok,
                onFailure: ApiResults.Problem
            );
        }

    }
}