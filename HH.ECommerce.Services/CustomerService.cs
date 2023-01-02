using HH.ECommerce.Entities;
using HH.ECommerce.Services.Contracts;
using HH.ECommerce.Data.Contracts;

namespace HH.ECommerce.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repository;

        public CustomerService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _repository.Customer.GetAllCustomers(trackChanges: false);
            return customers;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _repository.Customer.CreateCustomer(customer, customerType: "Customer");
            await _repository.SaveAsync();

            return customer;
        }

        public async Task<Customer?> GetCustomerById(int Id)
        {
            var customer = await _repository.Customer.GetCustomerById(Id, trackChanges: false);
            return customer;
        }

        public async Task<Customer?> GetCustomerByName(string name)
        {
            var customer = await _repository.Customer.GetCustomersByName(name.Trim().ToLower(), trackChanges: false);
            return customer;
        }
    }
}