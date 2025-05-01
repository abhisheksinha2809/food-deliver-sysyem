using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPaymentAsync(Payment payment);
        Task<Payment> GetPaymentByOrderIdAsync(int orderId);
    }
}