using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _repository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _repository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}