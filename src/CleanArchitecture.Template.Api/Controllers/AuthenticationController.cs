using CleanArchitecture.Template.Api.Constants;
using CleanArchitecture.Template.Api.Helpers;
using CleanArchitecture.Template.Api.Results;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser;
using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser.DTOs;
using CleanArchitecture.Template.Application.Users.Query.GetCurrentUser;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var result = await _sender.Send(new LoginUserCommand(request.UsernameOrEmail, request.Password));

            return result.Match(
                onSuccess: loginResponse =>
                {
                    CookieHelper.SetCookie(
                        Response,
                        nameof(RefreshToken),
                        loginResponse.RefreshToken.Token,
                        loginResponse.RefreshToken.ExpirationDate);

                    return Ok(loginResponse.AccessToken);
                },
                onFailure: ApiResults.Problem);
        }

        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var query = new GetCurrentUserQuery();
            var result = await _sender.Send(query);

            return result.Match(
                onSuccess: Ok,
                onFailure: ApiResults.Problem);

        }
    }
}