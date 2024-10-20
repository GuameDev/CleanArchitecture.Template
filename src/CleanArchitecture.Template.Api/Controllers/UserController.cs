using CleanArchitecture.Template.Api.Results;
using CleanArchitecture.Template.Application.Users.Query.GetById;
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

        /// <summary>
        /// Get an user by his ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetUserByIdQuery(id));
            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);

        }
    }
}
