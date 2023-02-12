using MediatR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using wtalk.Cqrs.Commands.Message;
using wtalk.Cqrs.Queries.Message;
using Wtalk.Core.Responses.Message;
using Wtalk.Core.Specifications.Message;

namespace wtalk.Controllers
{
    [Route("api/message")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
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

        [HttpGet("list")]
        [SwaggerOperation(Summary = "Get message list.", Description = "Get message list.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetMessageListResponse>> GetMessageList([FromQuery] MessageSpecParams specParams)
        {
            var response = await _mediator.Send(new GetMessageListQuery { MessageSpecParams = specParams });
            return Ok(response);
        }
    }
}
