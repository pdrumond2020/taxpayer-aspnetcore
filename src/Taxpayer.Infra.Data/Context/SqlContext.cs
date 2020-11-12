using Microsoft.EntityFrameworkCore;
using Taxpayer.Domain.Entities;
using Taxpayer.Infra.Data.Mapper;

namespace Taxpayer.Infra.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PayerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}