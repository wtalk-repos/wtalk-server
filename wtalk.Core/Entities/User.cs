using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtalk.Core.Entities
{
    public class User:BaseEntity
    {
        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? LastName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Password { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Salt { get; set; }
        public byte[]? Avatar { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
