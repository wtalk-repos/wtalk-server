using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Entities;
using Wtalk.Core.Interfaces.Repositories;

namespace Wtalk.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity>? Repository<TEntity>() where TEntity : BaseEntity;
        IUserRepository UserRepository { get; }
        Task<int> Complete();
    }
}