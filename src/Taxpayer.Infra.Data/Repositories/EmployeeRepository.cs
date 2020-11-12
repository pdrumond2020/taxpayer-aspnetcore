using Taxpayer.Domain.Entities;
using Taxpayer.Domain.Interface.Repositories;
using Taxpayer.Infra.Data.Context;
using Taxpayer.Infra.Data.Repositories.Base;

namespace Taxpayer.Infra.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SqlContext context)
            : base(context)
        {
        }
    }
}