using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Enums;

namespace Wtalk.Core.Entities
{
    public class FriendRequest:BaseEntity
    {
        public int InitiatorId { get; set; }
        public User Initiator { get; set; }
        public int PendingUserId { get; set; }
        public User PendingUser { get; set; }
        public FriendRequestStatus Status { get; set; } = FriendRequestStatus.Pending;

    }
}
