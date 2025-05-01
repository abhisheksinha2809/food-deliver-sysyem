using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _repository.AddAsync(restaurant);
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            await _repository.UpdateAsync(restaurant);
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
