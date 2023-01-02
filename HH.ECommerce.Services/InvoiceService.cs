using HH.ECommerce.Data.Contracts;
using HH.ECommerce.Entities;
using HH.ECommerce.Services.Contracts;

namespace HH.ECommerce.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepositoryManager _repository;

        public InvoiceService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<Invoice?> GetInvoice(string billNumber)
        {
            var invoice = await _repository.Invoice.GetTotalInvoiceAmount(billNumber, trackChanges: false);
            return invoice;
        }

        public async Task<decimal?> GenerateInvoiceForACustomer(int customerId, Invoice invoice)
        {
            decimal invoiceSubtotal = 0;

            var customer = await _repository.Customer.GetCustomerById(customerId, false);
            if (customer == null)
                return null;

            invoiceSubtotal = await ApplyDiscount(invoice, invoiceSubtotal, customer);
            invoice.Total = invoiceSubtotal;

            _repository.Invoice.GenerateInvoiceForCustomer(customerId, invoice);
            await _repository.SaveAsync();

            return invoice.Total;
        }

        private async Task<decimal> ApplyDiscount(Invoice invoice, decimal invoiceSubtotal, Customer customer)
        {
            var discounts = await _repository.Discount.GetAllDiscounts(false);
            decimal totalDiscountAmount = 0;

            var didPercentageApplied = false;

            foreach (var discount in discounts)
            {
                var didPercentageAppliedForAnyProduct = false;

                foreach (var detail in invoice.InvoiceDetails)
                {
                    if (discount.Equals(customer.CustomerType) && discount.IsRatePercentage && !didPercentageApplied && !detail.IsGroceries)
                    {
                        var discountAmount = detail.DerivedProductCost * (discount.Rate / 100);
                        totalDiscountAmount += discountAmount;

                        didPercentageAppliedForAnyProduct = true;
                    }
                    else if (detail.DerivedProductCost >= 100 && !discount.IsRatePercentage)
                    {
                        totalDiscountAmount += discount.Rate;
                    }
                }

                if (didPercentageAppliedForAnyProduct)
                {
                    didPercentageApplied = true;
                }
            }

            return invoice.OrderTotal - totalDiscountAmount;
        }
    }
}