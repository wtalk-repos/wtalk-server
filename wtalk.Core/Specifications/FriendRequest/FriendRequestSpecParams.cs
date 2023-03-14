using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtalk.Core.Specifications.FriendRequest
{
    public class FriendRequestSpecParams:BaseSpecParams
    {
        public int InitiatorId { get; set; }
        public int PendingUserId { get; set; }
    }
}
