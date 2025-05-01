using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task<Customer> RegisterCustomerAsync(Customer customer)
        {
            return await _customerRepository.CreateCustomerAsync(customer);
        }

        public async Task<Customer> UpdateCustomerAsync(int customerId, Customer customer)
        {
            return await _customerRepository.UpdateCustomerAsync(customerId, customer);
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            return await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}