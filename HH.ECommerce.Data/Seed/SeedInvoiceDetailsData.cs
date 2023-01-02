using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Seed
{
    public class SeedInvoiceDetailsData : IEntityTypeConfiguration<InvoiceDetails>
    {
        public static IEnumerable<InvoiceDetails> SeedInvoiceDetails = new InvoiceDetails[]
        {
            // First customer
            new InvoiceDetails
            { 
                // only loyal customer discount applied here
                Id = 1,
                InvoiceId = 1,
                ProductId = 2,
                IsGroceries = false,
                ProductName = "Item 2",
                ProductPrice = 20,
                ProductQuantity = 2,
                DerivedProductCost = 40,
                DiscountPrice = 2,
                TotalDerivedCost = 38
            },
            new InvoiceDetails
            {
                // only price per $100 discount applied here (given that a percentage based discount)
                // has already been applied to this customer
                Id = 2,
                InvoiceId = 1,
                ProductId = 4,
                IsGroceries = false,
                ProductName = "Item 4",
                ProductPrice = 482,
                ProductQuantity = 1,
                DerivedProductCost = 482,
                DiscountPrice = 20,
                TotalDerivedCost = 462
            },

            // Second customer (recently joined, and price less than $100)
            // no discount applied
            new InvoiceDetails
            {
                Id = 3,
                InvoiceId = 2,
                ProductId = 40,
                IsGroceries = false,
                ProductName = "Item 40",
                ProductPrice = 50,
                ProductQuantity = 5,
                DerivedProductCost = 250,
                DiscountPrice = 0,
                TotalDerivedCost = 250
            },

            // Affiliate
            new InvoiceDetails
            {
                // only affiliate discount applied here
                Id = 4,
                InvoiceId = 3,
                ProductId = 3,
                IsGroceries = false,
                ProductName = "Item 3",
                ProductPrice = 50,
                ProductQuantity = 5,
                DerivedProductCost = 250,
                DiscountPrice = 25,
                TotalDerivedCost = 225
            },
            new InvoiceDetails
            {
                // only price per $100 discount applied here (given that a percentage based discount)
                // has already been applied to this customer
                Id = 5,
                InvoiceId = 3,
                ProductId = 5,
                IsGroceries = false,
                ProductName = "Item 5",
                ProductPrice = 400,
                ProductQuantity = 1,
                DerivedProductCost = 400,
                DiscountPrice = 20,
                TotalDerivedCost = 380
            },
            new InvoiceDetails
            {
                // no discount applied due to:
                // this customer has already had the affiliate discount applied and price is less than $100
                Id = 6,
                InvoiceId = 3,
                ProductId = 15,
                IsGroceries = true,
                ProductName = "Item 15",
                ProductPrice = 77,
                ProductQuantity = 5,
                DerivedProductCost = 385,
                DiscountPrice = 0,
                TotalDerivedCost = 385
            },

            // Employee
            new InvoiceDetails
            {
                // Both the percentage based discount and price based discount is 
                // applied to this customer
                Id = 7,
                InvoiceId = 4,
                ProductId = 105,
                IsGroceries = false,
                ProductName = "Item 105",
                ProductPrice = 200,
                ProductQuantity = 5,
                DerivedProductCost = 1000,
                DiscountPrice = 80,
                TotalDerivedCost = 920
            }
        };

        public void Configure(EntityTypeBuilder<InvoiceDetails> builder)
        {
            builder.HasData(SeedInvoiceDetails);
        }
    }
}
