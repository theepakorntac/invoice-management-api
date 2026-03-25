using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderStatusesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatus>>> GetStatuses()
        {
            return await _context.OrderStatuses
                .FromSqlRaw("EXEC sp_GetAllOrderStatuses")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatus>> GetStatus(int id)
        {
            var idParam = new SqlParameter("@StatusID", id);
            var statuses = await _context.OrderStatuses
                .FromSqlRaw("EXEC sp_GetOrderStatusById @StatusID", idParam)
                .ToListAsync();

            var status = statuses.FirstOrDefault();
            if (status == null) return NotFound();
            return status;
        }

        [HttpPost]
        public async Task<ActionResult<OrderStatus>> PostStatus(OrderStatus status)
        {
            var p1 = new SqlParameter("@StatusName", status.StatusName);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertOrderStatus @StatusName", p1);

            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, OrderStatus status)
        {
            if (id != status.StatusID) return BadRequest();

            var p0 = new SqlParameter("@StatusID", id);
            var p1 = new SqlParameter("@StatusName", status.StatusName);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateOrderStatus @StatusID, @StatusName",
                p0, p1);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var idParam = new SqlParameter("@StatusID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteOrderStatus @StatusID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}