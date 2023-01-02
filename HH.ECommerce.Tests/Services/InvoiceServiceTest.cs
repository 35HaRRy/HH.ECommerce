using FluentAssertions;
using HH.ECommerce.Data.Seed;
using HH.ECommerce.Services;
using HH.ECommerce.Tests.Fixtures;

namespace HH.ECommerce.Tests.Services
{
    public class InvoiceServiceTest : IClassFixture<RepositoryFixture>
    {
        InvoiceService _invoiceService;

        public InvoiceServiceTest(RepositoryFixture fixture)
        {
            // Arrange
            _invoiceService = new InvoiceService(fixture.RepositoryManager);
        }

        [Fact]
        public void ShouldReturns_FirstInvoice()
        {
            // Arrange
            var invoice = SeedInvoiceData.SeedInvoices.First();

            // Act
            var invoiceByBillNumber = _invoiceService.GetInvoice(invoice.InvoiceNumber);

            // Assert
            invoiceByBillNumber
                .Should()
                .BeEquivalentTo(invoice);
        }

        [Fact]
        public async Task ShouldApply_DiscountForEmployee()
        {
            // Arrange
            var employee = SeedCustomerData.SeedCustomers.First(c => c.CustomerType.Equals("Employee"));
            var invoice = SeedInvoiceData.SeedInvoices.First(i => i.CustomerId == employee.CustomerId);
            var invoiceDetails = SeedInvoiceDetailsData.SeedInvoiceDetails
                .Where(id => id.InvoiceId == invoice.InvoiceId)
                .ToArray();
            invoice.InvoiceDetails = invoiceDetails;

            var actualTotal = invoice.InvoiceDetails.Sum(id => id.TotalDerivedCost);

            // Act
            var discountedTotal = await _invoiceService.GenerateInvoiceForACustomer(employee.CustomerId, invoice);

            // Assert
            discountedTotal
                .Should()
                .Be(actualTotal);
        }
    }
}
