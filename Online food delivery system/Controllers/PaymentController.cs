using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Interfaces;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<Payment>> ProcessPayment([FromBody] Payment payment)
        {
            try
            {
                var result = await _paymentService.ProcessPaymentAsync(payment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Payment/order/1
        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<Payment>> GetPaymentByOrderId(int orderId)
        {
            var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }
    }
}
