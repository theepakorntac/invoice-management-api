using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                .FromSqlRaw("EXEC sp_GetAllOrders")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var idParam = new SqlParameter("@OrderID", id);
            var orders = await _context.Orders
                .FromSqlRaw("EXEC sp_GetOrderById @OrderID", idParam)
                .ToListAsync();

            var order = orders.FirstOrDefault();
            if (order == null) return NotFound();
            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            var p1 = new SqlParameter("@CustomerID", order.CustomerID);
            var p2 = new SqlParameter("@OrderDate", order.OrderDate);
            var p3 = new SqlParameter("@StatusID", order.StatusID);
            var p4 = new SqlParameter("@TotalAmount", order.TotalAmount);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertOrder @CustomerID, @OrderDate, @StatusID, @TotalAmount",
                p1, p2, p3, p4);

            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderID) return BadRequest();

            var p0 = new SqlParameter("@OrderID", id);
            var p1 = new SqlParameter("@CustomerID", order.CustomerID);
            var p2 = new SqlParameter("@OrderDate", order.OrderDate);
            var p3 = new SqlParameter("@StatusID", order.StatusID);
            var p4 = new SqlParameter("@TotalAmount", order.TotalAmount);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateOrder @OrderID, @CustomerID, @OrderDate, @StatusID, @TotalAmount",
                p0, p1, p2, p3, p4);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var idParam = new SqlParameter("@OrderID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteOrder @OrderID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}