using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;

        public PaymentService(IPaymentRepository paymentRepository, IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Payment> ProcessPaymentAsync(Payment payment)
        {
            var order = await _orderRepository.GetByIdAsync(payment.OrderID);
            if (order == null)
                throw new Exception("Invalid Order ID");

            // Set payment amount from order total
            payment.Amount = order.TotalAmount;
            payment.Status = "Successful"; // Assume successful for simulation

            return await _paymentRepository.AddPaymentAsync(payment);
        }

        public async Task<Payment> GetPaymentByOrderIdAsync(int orderId)
        {
            return await _paymentRepository.GetPaymentByOrderIdAsync(orderId);
        }
    }
}