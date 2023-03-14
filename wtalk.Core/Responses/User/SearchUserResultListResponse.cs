using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Helpers;

namespace Wtalk.Core.Responses.User
{
    public class SearchUserResultListResponse
    {
        public Pagination<SearchUserResultResponse> Pagination { get; set; }
    }
}
