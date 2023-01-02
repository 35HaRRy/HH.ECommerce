using FluentAssertions;
using HH.ECommerce.Data.Repositories;
using HH.ECommerce.Data.Seed;
using HH.ECommerce.Tests.Fixtures;

namespace HH.ECommerce.Tests.Repositories
{
    public class CustomRepositoryTest : IClassFixture<DatabaseFixture>
    {
        CustomerRepository _customerRepository;

        public CustomRepositoryTest(DatabaseFixture fixture)
        {
            // Arrange
            _customerRepository = new CustomerRepository(fixture.DContext);
        }

        [Fact]
        public void ShouldCreate_Customer()
        {
            // Arrange
            var customer = SeedCustomerData.Customer;

            // Act
            _customerRepository.CreateCustomer(customer, "Customer");

            customer.CustomerId
                    .Should()
                    .NotBe(0);
        }

        [Fact]
        public async Task ShouldReturns_CustomerTypes()
        {
            // Act
            var customers = await _customerRepository.GetAllCustomers(false);

            // Assert
            customers
                .Should()
                .BeEquivalentTo(SeedCustomerData.SeedCustomerTypes);
        }

        [Fact]
        public async Task ShouldReturns_FirstCustomerById()
        {
            // Arrange
            var customer = SeedCustomerData.SeedCustomers.First();

            // Act
            var customerById = await _customerRepository.GetCustomerById(customer.CustomerId, false);

            // Assert
            customerById
                .Should()
                .BeEquivalentTo(customer);
        }

        [Fact]
        public async Task ShouldReturns_FirstCustomerByName()
        {
            // Arrange
            var customer = SeedCustomerData.SeedCustomers.First();

            // Act
            var customerByName = await _customerRepository.GetCustomersByName(customer.FirstName, false);

            // Assert
            customerByName
                .Should()
                .BeEquivalentTo(customer);
        }
    }
}