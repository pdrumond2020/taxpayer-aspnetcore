using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Taxpayer.Domain.Interface.Repositories.Base
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void AddAsync(TEntity obj);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
    }
}