using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Taxpayer.Domain.Interface.Repositories;
using Taxpayer.Domain.Interface.UnitOfWork;
using Taxpayer.Infra.Data.Context;
using Taxpayer.Infra.Data.Repositories;

namespace Taxpayer.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _sqlContext;

        public UnitOfWork(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_sqlContext);

        public async Task<bool> CompletedAsync()
        {
            bool returnValue = true;

            var strategy = _sqlContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = _sqlContext.Database.BeginTransaction();
                try
                {
                    await _sqlContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    var result = ex.Message.ToString();
                    returnValue = false;
                    transaction.Rollback();
                    throw;
                }
            });

            return returnValue;
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _sqlContext.Dispose();
            }
            disposedValue = true;
        }

        ~UnitOfWork()
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