using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtalk.Core.Entities
{
    public class Message:BaseEntity
    {
        public User Sender { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
        public User Receiver { get; set; }
        public int ReceiverId { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
