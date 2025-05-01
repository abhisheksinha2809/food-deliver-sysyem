using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            var orders = await _service.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Order order)
        {
            await _service.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetById), new { id = order.OrderID }, order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }
            await _service.UpdateOrderAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
