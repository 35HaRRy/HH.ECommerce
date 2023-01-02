using Microsoft.EntityFrameworkCore;

using HH.ECommerce.Data.Seed;

namespace HH.ECommerce.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeedCustomerData());
            modelBuilder.ApplyConfiguration(new SeedDiscountData());
            modelBuilder.ApplyConfiguration(new SeedInvoiceData());
            modelBuilder.ApplyConfiguration(new SeedInvoiceDetailsData());
        }
    }
}
