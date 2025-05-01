using Microsoft.EntityFrameworkCore;
using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly FoodDbContext _context;

        public PaymentRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddPaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> GetPaymentByOrderIdAsync(int orderId)
        {
            return await _context.Payments
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.OrderID == orderId);
        }
    }
}
