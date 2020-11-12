namespace Taxpayer.Domain.Entities
{
    public class Employee
    {
        public int Id { get; private set; }

        public string IdentificationNumber { get; private set; }

        public string Name { get; private set; }

        public decimal GrossSalary { get; private set; }

        public int NumberOfDependants { get; private set; }

        public decimal? ValueTaxIR { get; set; }

        public Employee()
        {
        }

        public Employee(string identificationNumber, string name, decimal grossSalary, int numberOfDependants)
        {
            IdentificationNumber = identificationNumber;
            Name = name;
            GrossSalary = grossSalary;
            NumberOfDependants = numberOfDependants;
        }
    }
}