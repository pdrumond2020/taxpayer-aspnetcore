using System.Runtime.Serialization;

namespace Taxpayer.Application.Model.RequestResponse
{
    [DataContract(Name = "employee")]
    public class EmployeeResponse
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string IdentificationNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal GrossSalary { get; set; }

        [DataMember]
        public int NumberOfDependants { get; set; }

        [DataMember]
        public decimal? ValueTaxIR { get; set; }
    }
}