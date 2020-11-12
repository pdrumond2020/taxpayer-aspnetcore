namespace Taxpayer.Domain.Entities
{
    public class RuleApplyTaxExempt : ITaxRule
    {
        public ITaxRule NextApply { get; set; }

        public decimal ApplyTax(decimal minimumWage, decimal netSalary)
        {
            if (netSalary <= minimumWage * 2)
            {
                return 0;
            }
            return NextApply.ApplyTax(minimumWage, netSalary);
        }
    }
}