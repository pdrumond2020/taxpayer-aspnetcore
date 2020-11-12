using System.Collections.Generic;
using System.Threading.Tasks;
using Taxpayer.Application.Model.RequestResponse;

namespace Taxpayer.Domain.Interface.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> ListAsync();

        Task<EmployeeResponse> ListByIdetificationNumberAsync(string identificationNUmber);

        void InsertAsync(EmployeeRequest payerRequest);

        Task<IEnumerable<EmployeeResponse>> ListCalculationIR(decimal minimumWage);
    }
}