using System.Threading.Tasks;

using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Contracts
{
    public interface IInvoiceRepository
    {
        Task<Invoice?> GetTotalInvoiceAmount(string billNumber, bool trackChanges);
        void GenerateInvoiceForCustomer(int customerId, Invoice invoice);
    }
}
