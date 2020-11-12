using System.Collections.Generic;
using System.Threading.Tasks;
using Taxpayer.Application.Model.RequestResponse;

namespace Taxpayer.Application.Interface
{
    public interface IEmployeeAppService
    {
        Task<MessageResponse<IEnumerable<EmployeeResponse>>> ListAsync();

        Task<MessageResponse<EmployeeResponse>> InsertAsync(EmployeeRequest employeeRequest);

        Task<MessageResponse<IEnumerable<EmployeeResponse>>> ListCalculationIR(decimal minimumWage);
    }
}