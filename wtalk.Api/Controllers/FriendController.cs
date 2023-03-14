using MediatR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Wtalk.Core.Specifications.Friend;
using Wtalk.Cqrs.Queries;

namespace wtalk.Controllers
{
    [Route("api/friend")]
    [ApiController]
    [Authorize]
    public class FriendController: ControllerBase
    {
        private readonly IMediator _mediator;

        public FriendController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("list")]
        [SwaggerOperation(Summary = "Get friends list", Description = "Get users friends list; filter by favourties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFriendsList([FromQuery] FriendSpecParams request)
        {
            var response = await _mediator.Send(new GetFriendsListQuery
            {
                SpecParams = request
            });
            return Ok(response);
        }

    }
}
