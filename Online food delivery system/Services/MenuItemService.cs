using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;

        public MenuItemService(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            await _repository.AddAsync(menuItem);
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            await _repository.UpdateAsync(menuItem);
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
