using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtalk.Infrastracture.Data.Context
{
    public class DbReadContext:WtalkContext
    {
        public DbReadContext(DbContextOptions<DbReadContext> options):base(options)
        {

        }
    }
}
