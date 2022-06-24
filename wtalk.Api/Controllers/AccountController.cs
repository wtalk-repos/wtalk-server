using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using wtalk.Cqrs.Commands;
using wtalk.Cqrs.Commands.Account;

namespace wtalk.Controllers
{
    [Route("api/account")]
    [ApiController]
    [Authorize]
    public class AccountController:ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Signup user.", Description = "Signup user.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUp(SignUpUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Sign in user.", Description = "Sign in user.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignIn(SignInUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
