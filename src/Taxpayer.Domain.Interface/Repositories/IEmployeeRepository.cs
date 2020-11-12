using Taxpayer.Domain.Entities;
using Taxpayer.Domain.Interface.Repositories.Base;

namespace Taxpayer.Domain.Interface.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}