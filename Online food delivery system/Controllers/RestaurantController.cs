using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAll()
        {
            var restaurants = await _service.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetById(int id)
        {
            var restaurant = await _service.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Restaurant restaurant)
        {
            await _service.AddRestaurantAsync(restaurant);
            return CreatedAtAction(nameof(GetById), new { id = restaurant.RestaurantID }, restaurant);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Restaurant restaurant)
        {
            if (id != restaurant.RestaurantID)
            {
                return BadRequest();
            }
            await _service.UpdateRestaurantAsync(restaurant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteRestaurantAsync(id);
            return NoContent();
        }
    }
}