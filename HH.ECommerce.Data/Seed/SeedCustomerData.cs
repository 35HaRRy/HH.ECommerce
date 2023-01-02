using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Seed
{
    public class SeedCustomerData : IEntityTypeConfiguration<Customer>
    {
        public static Customer Customer = new Customer
        {
            FirstName = "Micheal",
            MiddleName = "Smith",
            LastName = "Peers",
            Address = "3010 North Bend River Road",
            Email = "customer32@email.com",
            PhoneNumber = "123456789",
            CustomerType = "Customer",
            DateCreated = new DateTime(DateTime.Now.Year, 12, 1)
        };
        public static IEnumerable<Customer> SeedCustomerTypes = new Customer[]
        {
            new Customer
            {
                CustomerId = 1,
                FirstName = "Sheldon",
                MiddleName = "Lee",
                LastName = "Cooper",
                Address = "3008 North Bend River Road",
                Email = "customer1@email.com",
                PhoneNumber = "123456789",
                CustomerType = "Customer",
                DateCreated = new DateTime(DateTime.Now.Year - 3, 1, 1)
            },
            new Customer
            {
                CustomerId = 2,
                FirstName = "Leonard",
                MiddleName = "Lee",
                LastName = "Hoffsteder",
                Address = "4592 Chapel Street",
                Email = "customer2@email.com",
                PhoneNumber = "12345678910",
                CustomerType = "Customer",
                DateCreated = new DateTime(DateTime.Now.Year - 1, 9, 1)
            }
        };
        public static IEnumerable<Customer> SeedCustomers = SeedCustomerTypes.Concat(
            new Customer[]
            {
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Penny",
                    MiddleName = "L.",
                    LastName = "Jackson",
                    Address = "2306 Bird Street",
                    Email = "customer3@email.com",
                    PhoneNumber = "123456789",
                    CustomerType = "Affiliate",
                    DateCreated = new DateTime(DateTime.Now.Year - 1, 1, 1)
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Amy",
                    LastName = "Fowler",
                    Address = "3229 Counts Lane",
                    Email = "customer4@email.com",
                    PhoneNumber = "123456789",
                    CustomerType = "Employee",
                    DateCreated = new DateTime(DateTime.Now.Year - 5, 1, 1)
                },
                new Customer
                {
                    CustomerId = 5,
                    FirstName = "Raj",
                    LastName = "Koothrappali",
                    Address = "1608 Ashton Lane",
                    Email = "customer5@email.com",
                    PhoneNumber = "123456789",
                    CustomerType = "Employee",
                    DateCreated = new DateTime(DateTime.Now.Year - 3, 1, 1)
                }
            }
        );

        public void Configure(EntityTypeBuilder<Customer> builder) => builder.HasData(SeedCustomers);
    }
}
