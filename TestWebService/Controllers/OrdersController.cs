using Microsoft.AspNetCore.Mvc;
using TestWebService.Models;
using TestWebService.Services;

namespace TestWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _service;
        public OrdersController(OrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _service.GetAll();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetOrderById(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderRequest request)
        {
            var orderPost = await _service.CreateOrder(request);

            return Ok(orderPost);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteOrder(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
