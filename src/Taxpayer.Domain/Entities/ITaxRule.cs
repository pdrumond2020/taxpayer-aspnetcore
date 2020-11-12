using System;

namespace Taxpayer.Domain.Entities
{
    public interface ITaxRule
    {
        ITaxRule NextApply { get; set; }

        Decimal ApplyTax(decimal minimumWage, decimal netSalary);
    }
}