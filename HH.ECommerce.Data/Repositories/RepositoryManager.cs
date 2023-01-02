using System.Threading.Tasks;

using HH.ECommerce.Data.Contracts;

namespace HH.ECommerce.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext _context;

        private IDiscountRepository _discount;
        private IInvoiceRepository _invoice;
        private ICustomerRepository _customer;

        public RepositoryManager(ApplicationContext context) => _context = context;

        public IDiscountRepository Discount
        {
            get
            {
                if (_discount == null)
                    _discount = new DiscountRepository(_context);

                return _discount;
            }
        }

        public IInvoiceRepository Invoice
        {
            get
            {
                if (_invoice == null)
                    _invoice = new InvoiceRepository(_context);

                return _invoice;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                    _customer = new CustomerRepository(_context);

                return _customer;
            }
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync(); 
    }
}
