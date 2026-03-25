using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceStatusesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoiceStatusesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceStatus>>> GetStatuses()
        {
            return await _context.InvoiceStatuses
                .FromSqlRaw("EXEC sp_GetAllInvoiceStatuses")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceStatus>> GetStatus(int id)
        {
            var idParam = new SqlParameter("@InvoiceStatusID", id);
            var statuses = await _context.InvoiceStatuses
                .FromSqlRaw("EXEC sp_GetInvoiceStatusById @InvoiceStatusID", idParam)
                .ToListAsync();

            var status = statuses.FirstOrDefault();
            if (status == null) return NotFound();
            return status;
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceStatus>> PostStatus(InvoiceStatus status)
        {
            var p1 = new SqlParameter("@StatusName", status.StatusName);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertInvoiceStatus @StatusName", p1);

            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, InvoiceStatus status)
        {
            if (id != status.InvoiceStatusID) return BadRequest();

            var p0 = new SqlParameter("@InvoiceStatusID", id);
            var p1 = new SqlParameter("@StatusName", status.StatusName);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateInvoiceStatus @InvoiceStatusID, @StatusName",
                p0, p1);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var idParam = new SqlParameter("@InvoiceStatusID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteInvoiceStatus @InvoiceStatusID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}