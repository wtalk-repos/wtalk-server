using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Entities;

namespace Wtalk.Infrastracture.Data.Context
{
    public class WtalkContext : DbContext
    {
        public WtalkContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAvatar> UserAvatars { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserFriend>().HasOne(x => x.User).WithMany(e => e.UserFriends);
           
            modelBuilder.Entity<UserFriend>().HasOne(x => x.Friend);

           

            modelBuilder.Entity<UserFriend>().HasKey(e => new { e.UserId, e.FriendId });

    
        }
    }
}