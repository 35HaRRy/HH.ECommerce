using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Seed
{
    public class SeedInvoiceData : IEntityTypeConfiguration<Invoice>
    {
        public static IEnumerable<Invoice> SeedInvoices = new Invoice[]
        {
            new Invoice
            {
                InvoiceId = 1,
                OrderId  = 1,
                InvoiceNumber = "SRU001",
                CustomerId = 1, // customer
                Total = 500,
            },
            new Invoice
            {
                InvoiceId = 2,
                OrderId = 2,
                InvoiceNumber = "SRU002",
                CustomerId = 2, // customer
                Total = 1500,
            },
            new Invoice
            {
                InvoiceId = 3,
                OrderId = 3,
                InvoiceNumber = "SRU003",
                CustomerId = 3, // affiliate
                Total = 990,
            },
            new Invoice
            {
                InvoiceId = 4,
                OrderId = 4,
                InvoiceNumber = "SRU004",
                CustomerId = 4, // employee
                Total = 920,
            }
        };

        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasData(SeedInvoices);
        }
    }
}
