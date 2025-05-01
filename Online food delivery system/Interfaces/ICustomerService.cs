using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> RegisterCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(int customerId, Customer customer);
        Task<bool> DeleteCustomerAsync(int customerId);
    }
}