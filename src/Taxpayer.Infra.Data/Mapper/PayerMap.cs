using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Taxpayer.Domain.Entities;

namespace Taxpayer.Infra.Data.Mapper
{
    public class PayerMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.IdentificationNumber);
            builder.Property(x => x.Name);
            builder.Property(x => x.GrossSalary);
            builder.Property(x => x.NumberOfDependants);
            builder.Ignore(x => x.ValueTaxIR);
        }
    }
}