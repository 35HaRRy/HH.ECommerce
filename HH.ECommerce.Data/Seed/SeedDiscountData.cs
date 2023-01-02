using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Seed
{
    public class SeedDiscountData : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasData
            (
                new Discount
                {
                    Id = 1,
                    Name = "Affiliate Discount",
                    Type = "Affiliate",
                    Rate = 10,
                    IsRatePercentage = true
                },
                new Discount
                {
                    Id = 2,
                    Name = "Employee Discount",
                    Type = "Employee",
                    Rate = 30,
                    IsRatePercentage = true
                },
                new Discount
                {
                    Id = 3,
                    Name = "Loyal Customer Discount",
                    Type = "Customer",
                    Rate = 5,
                    IsRatePercentage = true
                },
                new Discount
                {
                    Id = 4,
                    Name = "Price Discount",
                    Type = "Price",
                    Rate = 5,
                    IsRatePercentage = false
                }
            );
        }
    }
}
