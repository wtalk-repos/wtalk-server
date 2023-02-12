using MediatR;
using Wtalk.Core.Responses.Message;

namespace wtalk.Cqrs.Commands.Message
{
    public class SendAndPersistMessageCommand:IRequest<CreateMessageResponse>
    {
        public int SenderId { get; set; }
        public string Text { get; set; }
        public int ReceiverId { get; set; }
    }
}
