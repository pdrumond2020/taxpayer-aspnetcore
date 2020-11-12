using System;
using Taxpayer.Domain.Entities;
using Xunit;

namespace Taxpayer.Domain.Test
{
    public class InputForTaxRuleTest
    {
        [Fact]
        public void CalculateNetSalary_WithDependents_IsSucess()
        {
            var minimumWage = 954M;
            Employee employee = new Employee("448.028.616-05", "Patricia", 2000, 2);
            var inputForTaxRule = new InputForTaxRule(minimumWage);
            var expected = 1904.6M;

            var result = inputForTaxRule.CalculateNetSalary(employee);

            Assert.IsType<Employee>(employee);
            Assert.IsType<decimal>(minimumWage);
            Assert.IsType<InputForTaxRule>(inputForTaxRule);
            Assert.IsType<decimal>(expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateNetSalary_WithoutDependents_IsSucess()
        {
            var minimumWage = 954M;
            Employee employee = new Employee("448.028.616-05", "Patricia", 2000, 0);
            var inputForTaxRule = new InputForTaxRule(minimumWage);
            var expected = 2000M;

            var result = inputForTaxRule.CalculateNetSalary(employee);

            Assert.IsType<Employee>(employee);
            Assert.IsType<decimal>(minimumWage);
            Assert.IsType<InputForTaxRule>(inputForTaxRule);
            Assert.IsType<decimal>(expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateValueTaxIr_Rule1_IsSucess()
        {
            var minimumWage = 954M;
            var netSalary = 1800M;
            var inputForTaxRule = new InputForTaxRule(minimumWage);
            var expected = 0M;

            var result = inputForTaxRule.CalculateValueTaxIr(netSalary);

            Assert.IsType<decimal>(minimumWage);
            Assert.IsType<decimal>(netSalary);
            Assert.IsType<InputForTaxRule>(inputForTaxRule);
            Assert.IsType<decimal>(expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateValueTaxIr_Rule2_IsSucess()
        {
            var minimumWage = 1000M;
            var netSalary = 2100M;
            var inputForTaxRule = new InputForTaxRule(minimumWage);
            var expected = 157.500M;

            var result = inputForTaxRule.CalculateValueTaxIr(netSalary);

            Assert.IsType<decimal>(minimumWage);
            Assert.IsType<decimal>(netSalary);
            Assert.IsType<InputForTaxRule>(inputForTaxRule);
            Assert.IsType<decimal>(expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateValueTaxIr_Rule3_IsSucess()
        {
            var minimumWage = 1000M;
            var netSalary = 4100M;
            var inputForTaxRule = new InputForTaxRule(minimumWage);
            var expected = 615M;

            var result = inputForTaxRule.CalculateValueTaxIr(netSalary);

            Assert.IsType<decimal>(minimumWage);
            Assert.IsType<decimal>(netSalary);
            Assert.IsType<InputForTaxRule>(inputForTaxRule);
            Assert.IsType<decimal>(expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateValueTaxIr_Rule4_IsSucess()
        {
            var minimumWage = 1000M;
            var netSalary = 5100M;
            var inputForTaxRule = new InputForTaxRule(minimumWage);
            var expected = 1147.500M;

            var result = inputForTaxRule.CalculateValueTaxIr(netSalary);

            Assert.IsType<decimal>(minimumWage);
            Assert.IsType<decimal>(netSalary);
            Assert.IsType<InputForTaxRule>(inputForTaxRule);
            Assert.IsType<decimal>(expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateValueTaxIr_Rule5_IsSucess()
        {
            var minimumWage = 1000M;
            var netSalary = 7100M;
            var inputForTaxRule = new InputForTaxRule(minimumWage);
            var expected = 1952.500M;

            var result = inputForTaxRule.CalculateValueTaxIr(netSalary);

            Assert.IsType<decimal>(minimumWage);
            Assert.IsType<decimal>(netSalary);
            Assert.IsType<InputForTaxRule>(inputForTaxRule);
            Assert.IsType<decimal>(expected);
            Assert.Equal(expected, result);
        }
    }
}