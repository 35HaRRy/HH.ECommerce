using HH.ECommerce.Entities;

namespace HH.ECommerce.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<Invoice?> GetInvoice(string billNumber);
        Task<decimal?> GenerateInvoiceForACustomer(int customerId, Invoice invoice);
    }
}