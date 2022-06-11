using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Entities;

namespace Wtalk.Infrastracture.Data.Context
{
    public class WtalkContext:DbContext
    {
        public WtalkContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}
