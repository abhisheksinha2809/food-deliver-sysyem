using Microsoft.EntityFrameworkCore;
using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodDbContext _context;

        public OrderRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
               .Include(o => o.Customer)
               .Include(o => o.Restaurant)
               .Include(o => o.OrderItems)
               .ThenInclude(oi => oi.MenuItem)
               .ThenInclude(mi => mi.Restaurant)
               .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Restaurant)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                        .ThenInclude(mi => mi.Restaurant)
                .FirstOrDefaultAsync(o => o.OrderID == id);
        }


        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }

}
