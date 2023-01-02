using Microsoft.EntityFrameworkCore;

using HH.ECommerce.Data.Contracts;
using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Repositories
{
    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationContext context) : base(context) { }

        public void GenerateInvoiceForCustomer(int customerId, Invoice invoice)
        {
            invoice.CustomerId = customerId;
            Create(invoice);
        }

        public async Task<Invoice?> GetTotalInvoiceAmount(string billNumber, bool trackChanges) => await FindByCondition(
            i => i.InvoiceNumber.Equals(billNumber),
            trackChanges
        )
        .SingleOrDefaultAsync();
    }
}
