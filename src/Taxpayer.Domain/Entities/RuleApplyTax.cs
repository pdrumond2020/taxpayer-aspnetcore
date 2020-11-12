namespace Taxpayer.Domain.Entities
{
    public class RuleApplyTax : ITaxRule
    {
        public ITaxRule NextApply { get; set; }
        public readonly decimal _tax;
        public readonly int _numberMinimumWages;

        public RuleApplyTax(decimal tax, int numberMinimumWages)
        {
            _tax = tax;
            _numberMinimumWages = numberMinimumWages;
        }

        public decimal ApplyTax(decimal minimumWage, decimal netSalary)
        {
            if (netSalary <= minimumWage * _numberMinimumWages)
            {
                return (_tax / 100) * netSalary;
            }
            return NextApply.ApplyTax(minimumWage, netSalary);
        }
    }
}