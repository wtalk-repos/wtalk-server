using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtalk.Core.Specifications.User
{
    public class UserSpecification:BaseSpecification<Core.Entities.User>
    {
        public UserSpecification(int id)
        {
            Criteria = (e => e.Id == id);
            AddInclude("UserFriends.Friend");
        }
    }
}
