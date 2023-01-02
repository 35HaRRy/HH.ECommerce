using HH.ECommerce.Entities;

namespace HH.ECommerce.Services.Contracts
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer?> GetCustomerById(int Id);
        Task<Customer?> GetCustomerByName(string name);
    }
}