using MediatR;
using Wtalk.Core.Responses.Message;
using Wtalk.Core.Specifications.Message;

namespace wtalk.Cqrs.Queries.Message
{
    public class GetMessageListQuery:IRequest<GetMessageListResponse>
    {
        public MessageSpecParams MessageSpecParams { get; set; }
    }
}
