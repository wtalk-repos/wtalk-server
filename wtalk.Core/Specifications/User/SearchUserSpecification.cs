using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtalk.Core.Specifications.User
{
    public class SearchUserSpecification : BaseSpecification<Core.Entities.User>
    {
        public SearchUserSpecification(UserSpecParams userSpecParams)
        {
            if (string.IsNullOrEmpty(userSpecParams.Search) == false)
                userSpecParams.Search = userSpecParams.Search.ToLower();

            Criteria = (x) => string.IsNullOrEmpty(userSpecParams.Search) == false &&
            (
            x.Username.ToLower().Contains(userSpecParams.Search) ||
            x.FirstName.ToLower().Contains(userSpecParams.Search) ||
            x.LastName.ToLower().Contains(userSpecParams.Search) ||
            x.Email.ToLower().Contains(userSpecParams.Search)
            );
            ApplyPaging(userSpecParams.PageSize * (userSpecParams.PageIndex - 1), userSpecParams.PageSize);
        }
    }
}
