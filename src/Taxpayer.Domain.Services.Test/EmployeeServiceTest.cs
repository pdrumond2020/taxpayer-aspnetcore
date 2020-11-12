using FizzWare.NBuilder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxpayer.Application.Model.RequestResponse;
using Taxpayer.Domain.Entities;
using Taxpayer.Domain.Interface.Repositories;
using Taxpayer.Domain.Interface.Services;
using Taxpayer.Domain.Interface.UnitOfWork;
using Taxpayer.Domain.Services.Mappers;
using Xunit;
using Xunit.Abstractions;

namespace Taxpayer.Domain.Services.Test
{
    public class EmployeeServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;

        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IEmployeeService _service;

        public EmployeeServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;

            _mockUoW = new Mock<IUnitOfWork>();
            _service = new EmployeeService(_mockUoW.Object);
        }

        [Fact]
        [Trait("Services", "EmployeeServices")]
        public void ListAsync_Returns_Success()
        {
            _testOutput.WriteLine("Lista não pode ser vazia.");
            var employees = Builder<Employee>.CreateListOfSize(10).All().Build();
            var expected = Task.FromResult((IEnumerable<Employee>)employees);

            _mockUoW
                .Setup(x => x.EmployeeRepository.GetAllAsync())
                .Returns(expected);

            var result = _service.ListAsync().Result;

            Assert.NotNull(employees);
            Assert.NotNull(result);
            Assert.IsType<List<EmployeeResponse>>(result.ToList());
            Assert.Equal(expected.Result.Count().ToString(), result.Count().ToString());
        }

        [Fact]
        [Trait("Services", "EmployeeServices")]
        public void ListByIdetificationNumberAsync_Returns_Success()
        {
            _testOutput.WriteLine("Objeto deve ser retornado.");
            var employee = Builder<Employee>.CreateNew().Build();
            var expected = Task.FromResult(employee);
            var identificationNUmber = employee.IdentificationNumber;
            var name = employee.Name;

            _mockUoW
                .Setup(x => x.EmployeeRepository.GetAsync(p => p.IdentificationNumber == identificationNUmber))
                .Returns(expected);

            var result = _service.ListByIdetificationNumberAsync(identificationNUmber).Result;

            Assert.NotNull(employee);
            Assert.NotNull(result);
            Assert.IsType<EmployeeResponse>(result);
            Assert.Equal(result.Name, expected.Result.Name);
        }

        [Fact]
        [Trait("Services", "EmployeeServices")]
        public void InsertAsync_Returns_Success()
        {
            _testOutput.WriteLine("Objeto deve retornar 1.");
            var employeeRequest = Builder<EmployeeRequest>
                .CreateNew()
                .With(p => p.GrossSalary = "1000")
                .With(p => p.NumberOfDependants = "2")
                .Build();
            var employee = EmployeeServiceMapper.ConvertRequestToObject(employeeRequest);
            var name = employee.Name;
            var expected = Task.FromResult(1);

            _mockUoW
                .Setup(x => x.EmployeeRepository.AddAsync(employee))
                .Verifiable();

            _service.InsertAsync(employeeRequest);

            Assert.NotNull(employee);
            Assert.NotNull(employeeRequest);
            Assert.IsType<EmployeeRequest>(employeeRequest);
            Assert.IsType<Employee>(employee);
        }

        [Fact]
        [Trait("Services", "EmployeeServices")]
        public void ListCalculationIR_Returns_Success()
        {
            var minimumWage = 1000;
            var employees = new List<Employee>()
            {
                new Employee("11111", "Patricia", 2000, 1)
            };
            var expectedIenum = Task.FromResult((IEnumerable<Employee>)employees);
            var employeeResponse = employees.Select(p => p.ConvertToResponse());
            var expected = 0M;

            _mockUoW
                .Setup(x => x.EmployeeRepository.GetAllAsync())
                .Returns(expectedIenum);

            var result = _service.ListCalculationIR(minimumWage).Result;

            Assert.NotNull(employees);
            Assert.NotNull(employeeResponse);
            Assert.Equal(result.ToList().First().ValueTaxIR, expected);
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }
    }
}