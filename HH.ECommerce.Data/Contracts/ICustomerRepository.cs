using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Contracts
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers(bool trackChanges);
        void CreateCustomer(Customer customer, string customerType);
        Task<Customer?> GetCustomerById(int customerId, bool trackChanges);
        Task<Customer?> GetCustomersByName(string name, bool trackChanges); 
    }
}
