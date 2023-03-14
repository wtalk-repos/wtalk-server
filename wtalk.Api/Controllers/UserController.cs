using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Wtalk.Cqrs.Queries;
using Wtalk.Core.Specifications.Friend;
using wtalk.Cqrs.Commands.User;
using Wtalk.Core.Specifications.User;
using wtalk.Cqrs.Queries.User;

namespace wtalk.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create user.", Description = "Create user.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(CreateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet("search")]   
        [SwaggerOperation(Summary = "Search users", Description = "Search users, return a pagination list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchUsers([FromQuery] UserSpecParams request)
        {
            var response = await _mediator.Send(new SearchUsersQuery
            {
                SpecParams = request
            });
            return Ok(response);
        }
    }
}
