using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Helpers;
using Wtalk.Core.Responses.Friend;

namespace Wtalk.Core.Responses.User
{
    public class SearchUserResultResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
