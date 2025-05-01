using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(int customerId, Customer customer);
        Task<bool> DeleteCustomerAsync(int customerId);
    }
}