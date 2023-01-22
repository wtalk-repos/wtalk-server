using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Wtalk.Core.Entities
{
    public class User : BaseEntity, ITrackable
    {
        public string? Username{ get; set; }
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
        public UserAvatar Avatar { get; set; }
        public List<UserFriend> UserFriends { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
