using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> ProcessPaymentAsync(Payment payment);
        Task<Payment> GetPaymentByOrderIdAsync(int orderId);
    }
}
