using MediatR;
using Wtalk.Core.Responses.FriendRequest;

namespace wtalk.Cqrs.Commands.FriendRequest
{
    public class CreateFriendRequestCommand:IRequest<CreateFriendRequestResponse>
    {
        public int FriendId { get; set; }
    }
}
