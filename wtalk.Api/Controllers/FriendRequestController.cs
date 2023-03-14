using MediatR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using wtalk.Cqrs.Commands.FriendRequest;

namespace wtalk.Controllers
{
    [Route("api/friend")]
    [ApiController]
    [Authorize]
    public class FriendRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FriendRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create friend request.", Description = "Persists friend request and sends a SignalR notification to user.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateFriendRequest(CreateFriendRequestCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
