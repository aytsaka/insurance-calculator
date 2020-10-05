using Insurance.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Data.Context
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {
        }

        public DbSet<SurchargeRate> SurchargeRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurchargeRate>(entity =>
            {
                entity.HasKey(e => e.ProductTypeId);
            });
        }
    }
}
