using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Taxpayer.Infra.CrossCutting.Utils;

namespace Taxpayer.Application.Model.RequestResponse
{
    [DataContract(Name = "employee")]
    public class EmployeeRequest
    {
        [DataMember]
        public string IdentificationNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string GrossSalary { get; set; }

        [DataMember]
        public string NumberOfDependants { get; set; }

        public List<Inconsistencies> Validate()
        {
            List<Inconsistencies> inconsistencies = new List<Inconsistencies>();

            if (String.IsNullOrEmpty(IdentificationNumber))
            {
                inconsistencies.Add(new Inconsistencies() { Field = "CPF", Description = "CPF Obrigatório" });
            }

            if (String.IsNullOrEmpty(Name))
            {
                inconsistencies.Add(new Inconsistencies() { Field = "Nome", Description = "Nome é Obrigatório" });
            }

            if (!CpfUtils.IsCpf(IdentificationNumber))
            {
                inconsistencies.Add(new Inconsistencies() { Field = "CPF", Description = "CPF inválido" });
            }

            if (Convert.ToDecimal(GrossSalary) < 99 || Convert.ToDecimal(GrossSalary) > 99999)
            {
                inconsistencies.Add(new Inconsistencies() { Field = "Renda Bruta", Description = "Renda bruta não pode ser menor que 100 e maior que 99999.99" });
            }

            if (Convert.ToInt32(NumberOfDependants) < 0 || Convert.ToInt32(NumberOfDependants) > 10)
            {
                inconsistencies.Add(new Inconsistencies() { Field = "Número de dependentes", Description = "Número de dependentes não pode ser menor que 0 e maior que 10" });
            }

            return inconsistencies;
        }
    }
}