using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Entities;

namespace Wtalk.Core.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User?> FindUserByEmailAsync(string email);
        Task<User> FindUserByUsernameAsync(string username);

    }
}
