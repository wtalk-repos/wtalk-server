using MediatR;
using System.Collections.Generic;
using Wtalk.Core.Responses.Friend;
using Wtalk.Core.Specifications.Friend;

namespace Wtalk.Cqrs.Queries
{
    public class GetFriendsListQuery:IRequest<FriendListResponse>
    {
        public FriendSpecParams SpecParams { get; set; }
    }
}
