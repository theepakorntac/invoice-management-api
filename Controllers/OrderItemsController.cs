using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _itemService;
        public OrderItemsController(IOrderItemService itemService) => _itemService = itemService;

        [HttpGet] // GET ALL
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAll()
            => Ok(await _itemService.GetAllAsync());

        [HttpGet("{id}")] // GET BY ID
        public async Task<ActionResult<OrderItem>> GetById(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        //[HttpGet("order/{orderId}")] // GET BY ORDER ID
        //public async Task<ActionResult<IEnumerable<OrderItem>>> GetByOrder(int orderId)
        //    => Ok(await _itemService.GetByOrderIdAsync(orderId));

        [HttpPost] // CREATE
        public async Task<ActionResult> Create(OrderItem item)
        {
            await _itemService.CreateAsync(item);
            return Ok(item);
        }

        [HttpPut("{id}")] // UPDATE
        public async Task<IActionResult> Update(int id, OrderItem item)
        {
            var result = await _itemService.UpdateAsync(id, item);
            return result == 0 ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")] // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _itemService.DeleteAsync(id);
            return result == 0 ? NotFound() : NoContent();
        }
    }
}