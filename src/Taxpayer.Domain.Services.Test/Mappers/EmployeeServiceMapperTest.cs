using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using Taxpayer.Application.Model.RequestResponse;
using Taxpayer.Domain.Entities;
using Taxpayer.Domain.Services.Mappers;
using Xunit;
using Xunit.Abstractions;

namespace Taxpayer.Domain.Services.Test.Mappers
{
    public class EmployeeServiceMapperTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;

        public EmployeeServiceMapperTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("Mapper Services", "Employee")]
        public void ConvertToResponseAsync_ReturnList_Success()
        {
            _testOutput.WriteLine("Objeto não pode ser nulo.");
            var expected = Builder<Employee>.CreateNew().Build();

            var result = EmployeeServiceMapper.ConvertObjectToResponse(expected);

            Assert.NotNull(expected);
            Assert.NotNull(result);
            Assert.IsType<Employee>(expected);
            Assert.IsType<EmployeeResponse>(result);
            Assert.Equal(expected.Name, result.Name);
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