using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Entities;
using Wtalk.Core.Interfaces;
using Wtalk.Core.Interfaces.Repositories;
using Wtalk.Infrastracture.Data.Context;
using Wtalk.Infrastracture.Repository;

namespace Wtalk.Infrastracture.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository _userRepository { get; set; }
        private Hashtable? _repositories{get;set;}
        public DbWriteContext _writeContext { get; set; }
        public UnitOfWork(DbWriteContext dbWriteContext)
        {
            _writeContext = dbWriteContext;
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_writeContext);
                }
                return _userRepository;
            }
        }

        public Task<int> Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {

            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _writeContext);

                _repositories.Add(type, repositoryInstance);
            }

            return _repositories[type] as IGenericRepository<TEntity>;

        }
    }
}
