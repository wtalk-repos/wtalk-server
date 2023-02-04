using MediatR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using wtalk.Cqrs.Commands.Message;
using Wtalk.Core.Responses.Message;

namespace wtalk.Controllers
{
    [Route("api/message")]
    [ApiController]
    [Authorize]
    public class MessageController:ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Send and persist message.", Description = "Send and persist message")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateMessageResponse>> SendAndPersistMessageCommand(SendAndPersistMessageCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
