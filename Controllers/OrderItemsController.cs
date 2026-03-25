using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            return await _context.OrderItems
                .FromSqlRaw("EXEC sp_GetAllOrderItems")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var idParam = new SqlParameter("@ItemID", id);
            var items = await _context.OrderItems
                .FromSqlRaw("EXEC sp_GetOrderItemById @ItemID", idParam)
                .ToListAsync();

            var item = items.FirstOrDefault();
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
            var p1 = new SqlParameter("@OrderID", orderItem.OrderID);
            var p2 = new SqlParameter("@ProductID", orderItem.ProductID);
            var p3 = new SqlParameter("@Quantity", orderItem.Quantity);
            var p4 = new SqlParameter("@UnitPrice", orderItem.UnitPrice);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertOrderItem @OrderID, @ProductID, @Quantity, @UnitPrice",
                p1, p2, p3, p4);

            return Ok(orderItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.ItemID) return BadRequest();

            var p0 = new SqlParameter("@ItemID", id);
            var p1 = new SqlParameter("@OrderID", orderItem.OrderID);
            var p2 = new SqlParameter("@ProductID", orderItem.ProductID);
            var p3 = new SqlParameter("@Quantity", orderItem.Quantity);
            var p4 = new SqlParameter("@UnitPrice", orderItem.UnitPrice);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateOrderItem @ItemID, @OrderID, @ProductID, @Quantity, @UnitPrice",
                p0, p1, p2, p3, p4);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var idParam = new SqlParameter("@ItemID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteOrderItem @ItemID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}