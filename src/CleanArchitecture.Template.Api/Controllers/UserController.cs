using CleanArchitecture.Template.Api.Results;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser;
using CleanArchitecture.Template.Application.Users.Commands.RegisterUser.DTOs;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var command = new RegisterUserCommand(request.Username, request.Email, request.FirstName, request.LastName1, request.LastName2, request.Password);
            var result = await _sender.Send(command);

            return result.Match(
                 onSuccess: () => CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value),
                 onFailure: ApiResults.Problem
             );
        }
        /// <summary>
        /// Get an user by his ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var result = await _sender.Send(new GetUserByIdQuery(id));
            //return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
            return Ok();
        }
    }
}
