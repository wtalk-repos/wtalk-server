using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Entities;
using Wtalk.Core.Interfaces.Repositories;
using Wtalk.Infrastracture.Data.Context;

namespace Wtalk.Infrastracture.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbWriteContext context):base(context)
        {

        }
        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await _writeContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
        public async Task<User> FindUserByUsernameAsync(string username)
        {
            return await _writeContext.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        }
    }
}
