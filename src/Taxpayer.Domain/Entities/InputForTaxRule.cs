namespace Taxpayer.Domain.Entities
{
    public class InputForTaxRule
    {
        public decimal DependentDiscountPercentage { get; private set; }
        public readonly decimal _minimumWage;

        public InputForTaxRule(decimal minimumWage)
        {
            DependentDiscountPercentage = 5;
            _minimumWage = minimumWage;
        }

        public Employee CalculateTaxpayer(Employee employee)
        {
            var netSalary = CalculateNetSalary(employee);
            employee.ValueTaxIR = CalculateValueTaxIr(netSalary);
            return employee;
        }

        public decimal CalculateNetSalary(Employee employee)
        {
            var valorDesconto = ((employee.NumberOfDependants * DependentDiscountPercentage) / 100) * _minimumWage;
            return employee.GrossSalary - valorDesconto;
        }

        public decimal CalculateValueTaxIr(decimal netSalary)
        {
            ITaxRule rule1 = new RuleApplyTaxExempt();
            ITaxRule rule2 = new RuleApplyTax(7.5m, 4);
            ITaxRule rule3 = new RuleApplyTax(15m, 5);
            ITaxRule rule4 = new RuleApplyTax(22.5m, 7);
            ITaxRule rule5 = new RuleApplyTaxGreatest(27.5m, 7);

            rule1.NextApply = rule2;
            rule2.NextApply = rule3;
            rule3.NextApply = rule4;
            rule4.NextApply = rule5;

            return rule1.ApplyTax(_minimumWage, netSalary);
        }
    }
}