using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtalk.Core.Entities
{
    public class UserAvatar:BaseEntity
    {
        public byte[]? Avatar { get; set; }
    }
}
