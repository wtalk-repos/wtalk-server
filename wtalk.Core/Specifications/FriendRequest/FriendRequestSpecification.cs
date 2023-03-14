namespace Wtalk.Core.Specifications.FriendRequest
{
    public class FriendRequestSpecification:BaseSpecification<Wtalk.Core.Entities.FriendRequest>
    {
        public FriendRequestSpecification(FriendRequestSpecParams specParams)
        {
            
        }
        public FriendRequestSpecification(int initiatorId, int pendingUserId)
        {
            Criteria = x => x.InitiatorId == initiatorId && x.PendingUserId == pendingUserId;
        }
    }
}
