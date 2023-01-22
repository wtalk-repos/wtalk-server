using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Wtalk.Core.Entities;
using Wtalk.Core.Interfaces.Repositories;
using Wtalk.Core.Specifications;
using Wtalk.Infrastracture.Data;
using Wtalk.Infrastracture.Data.Context;

namespace Wtalk.Infrastructure.Data.Repository
{
    public class ReadGenericRepository<T> : IReadGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbReadContext _readContext;

        public ReadGenericRepository(DbReadContext readContext)
        {
            _readContext = readContext;
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<List<TProjection>> GetAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection)
        {
            return await _readContext.Set<T>().AsNoTracking().Where(filter).Select(projection).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _readContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<T?> GetEntityWithSpec(int id, ISpecification<T> spec)
        {
            return await ApplySpecification(spec).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _readContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async  Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            var query = ApplySpecification(spec);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<TProjection>> ListAsync<TProjection>(ISpecification<T> spec, Expression<Func<T, TProjection>> projection)
        {
            var query = ApplySpecification(spec);

            return await query.AsNoTracking().Select(projection).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_readContext.Set<T>().AsQueryable(), spec);
        }
        public async Task<TProjection> GetFirstAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection)
        {
           return await _readContext.Set<T>().AsNoTracking().Where(filter).Select(projection).FirstOrDefaultAsync();
        }
    }
}
