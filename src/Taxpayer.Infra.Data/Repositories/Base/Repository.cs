using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Taxpayer.Domain.Interface.Repositories.Base;

namespace Taxpayer.Infra.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

        public void AddAsync(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> filter) => await _context.Set<TEntity>().Where(filter).ToListAsync().ConfigureAwait(false);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter) => await _context.Set<TEntity>().FirstOrDefaultAsync(filter).ConfigureAwait(false);

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter) => await _context.Set<TEntity>().AnyAsync(filter).ConfigureAwait(false);

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.DisposeAsync();
                }

                disposedValue = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}