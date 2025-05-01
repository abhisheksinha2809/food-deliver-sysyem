using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // Get all customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        // Get customer by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // Register a new customer
        [HttpPost]
        public async Task<ActionResult<Customer>> RegisterCustomer(Customer customer)
        {
            var createdCustomer = await _customerService.RegisterCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.CustomerID }, createdCustomer);
        }

        // Update an existing customer
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            var updatedCustomer = await _customerService.UpdateCustomerAsync(id, customer);
            if (updatedCustomer == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Delete a customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}