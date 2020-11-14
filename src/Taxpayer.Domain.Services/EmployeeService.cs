using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxpayer.Application.Model.RequestResponse;
using Taxpayer.Domain.Entities;
using Taxpayer.Domain.Interface.Repositories;
using Taxpayer.Domain.Interface.Services;
using Taxpayer.Domain.Interface.UnitOfWork;
using Taxpayer.Domain.Services.Mappers;

namespace Taxpayer.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<EmployeeResponse>> ListAsync()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAllAsync().Result.OrderBy(a => a.Name);
            return Task.FromResult(employees.Select(p => p.ConvertToResponse()));
        }

        public Task<EmployeeResponse> ListByIdetificationNumberAsync(string identificationNUmber)
        {
            var employee = _unitOfWork.EmployeeRepository
                .GetAsync(p => p.IdentificationNumber == identificationNUmber).Result;
            return Task.FromResult(EmployeeServiceMapper.ConvertObjectToResponse(employee));
        }

        public void InsertAsync(EmployeeRequest employeeRequest)
        {
            var employee = EmployeeServiceMapper.ConvertRequestToObject(employeeRequest);
            _unitOfWork.EmployeeRepository.AddAsync(employee);
        }

        public Task<IEnumerable<EmployeeResponse>> ListCalculationIR(decimal minimumWage)
        {
            InputForTaxRule inputForTaxRule = new InputForTaxRule(minimumWage);
            var employees = _unitOfWork.EmployeeRepository.GetAllAsync().Result;
            var employeesTax = employees.Select(x => inputForTaxRule.CalculateTaxpayer(x));
            var result = employeesTax.OrderBy(x => x.ValueTaxIR).ThenBy(x => x.Name).ToList();
            return Task.FromResult(result.Select(p => p.ConvertToResponse()));
        }
    }
}