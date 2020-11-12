using System;
using Taxpayer.Application.Model.RequestResponse;
using Taxpayer.Domain.Entities;

namespace Taxpayer.Domain.Services.Mappers
{
    public static class EmployeeServiceMapper
    {
        public static EmployeeResponse ConvertToResponse(this Employee employee) => ConvertObjectToResponse(employee);

        public static EmployeeResponse ConvertObjectToResponse(Employee employee)
        {
            if (employee == null) return null;

            return new EmployeeResponse
            {
                Id = employee.Id,
                Name = employee.Name,
                IdentificationNumber = employee.IdentificationNumber,
                GrossSalary = employee.GrossSalary,
                NumberOfDependants = employee.NumberOfDependants,
                ValueTaxIR = employee.ValueTaxIR == null ? null : employee.ValueTaxIR
            };
        }

        public static Employee ConvertRequestToObject(EmployeeRequest request) => new Employee(request.IdentificationNumber, request.Name, Convert.ToDecimal(request.GrossSalary), Convert.ToInt32(request.NumberOfDependants));
    }
}