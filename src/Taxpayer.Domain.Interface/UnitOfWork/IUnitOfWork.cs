using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Taxpayer.Domain.Interface.Repositories;

namespace Taxpayer.Domain.Interface.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }

        Task<bool> CompletedAsync();
    }
}