using Microsoft.EntityFrameworkCore;
using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodDbContext _context;

        public RestaurantRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            return await _context.Restaurants.FindAsync(id);
        }

        public async Task AddAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }
    }

}
