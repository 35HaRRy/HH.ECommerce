using Microsoft.EntityFrameworkCore;

using HH.ECommerce.Data.Contracts;
using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) : base(context) {  }

        public void CreateCustomer(Customer customer, string customerType)
        {
            customer.CustomerType = customerType;
            Create(customer); 
        }

        public async Task<List<Customer>> GetAllCustomers(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

        public async Task<Customer?> GetCustomerById(int customerId, bool trackChanges) => await FindByCondition(
            c => c.CustomerId.Equals(customerId),
            trackChanges
        )
        .SingleOrDefaultAsync();

        public async Task<Customer?> GetCustomersByName(string name, bool trackChanges) => await FindByCondition(
            c => 
                c.LastName
                    .Trim()
                    .ToLower()
                    .Contains(name)
                || c.MiddleName!
                    .Trim()
                    .ToLower()
                    .Contains(name)
                || c.FirstName
                    .Trim().ToLower()
                    .Contains(name), 
            trackChanges
        )
        .SingleOrDefaultAsync();
    }
}
