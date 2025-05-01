using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _service;

        public MenuItemController(IMenuItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAll()
        {
            var menuItems = await _service.GetAllMenuItemsAsync();
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetById(int id)
        {
            var menuItem = await _service.GetMenuItemByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<ActionResult> Create(MenuItem menuItem)
        {
            await _service.AddMenuItemAsync(menuItem);
            return CreatedAtAction(nameof(GetById), new { id = menuItem.ItemID }, menuItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MenuItem menuItem)
        {
            if (id != menuItem.ItemID)
            {
                return BadRequest();
            }
            await _service.UpdateMenuItemAsync(menuItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteMenuItemAsync(id);
            return NoContent();
        }
    }
}