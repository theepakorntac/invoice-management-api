using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoicesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return await _context.Invoices
                .FromSqlRaw("EXEC sp_GetAllInvoices")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var idParam = new SqlParameter("@InvoiceID", id);
            var invoices = await _context.Invoices
                .FromSqlRaw("EXEC sp_GetInvoiceById @InvoiceID", idParam)
                .ToListAsync();

            var invoice = invoices.FirstOrDefault();
            if (invoice == null) return NotFound();
            return invoice;
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            var p1 = new SqlParameter("@OrderID", invoice.OrderID);
            var p2 = new SqlParameter("@InvoiceDate", invoice.InvoiceDate);
            var p3 = new SqlParameter("@DueDate", invoice.DueDate);
            var p4 = new SqlParameter("@PaidDate", (object?)invoice.PaidDate ?? DBNull.Value);
            var p5 = new SqlParameter("@InvoiceStatusID", invoice.InvoiceStatusID);
            var p6 = new SqlParameter("@TotalAmount", invoice.TotalAmount);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertInvoice @OrderID, @InvoiceDate, @DueDate, @PaidDate, @InvoiceStatusID, @TotalAmount",
                p1, p2, p3, p4, p5, p6);

            return Ok(invoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.InvoiceID) return BadRequest();

            var p0 = new SqlParameter("@InvoiceID", id);
            var p1 = new SqlParameter("@OrderID", invoice.OrderID);
            var p2 = new SqlParameter("@InvoiceDate", invoice.InvoiceDate);
            var p3 = new SqlParameter("@DueDate", invoice.DueDate);
            var p4 = new SqlParameter("@PaidDate", (object?)invoice.PaidDate ?? DBNull.Value);
            var p5 = new SqlParameter("@InvoiceStatusID", invoice.InvoiceStatusID);
            var p6 = new SqlParameter("@TotalAmount", invoice.TotalAmount);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateInvoice @InvoiceID, @OrderID, @InvoiceDate, @DueDate, @PaidDate, @InvoiceStatusID, @TotalAmount",
                p0, p1, p2, p3, p4, p5, p6);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var idParam = new SqlParameter("@InvoiceID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteInvoice @InvoiceID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}