using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SuppliersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            return await _context.Suppliers
                .FromSqlRaw("EXEC sp_GetAllSuppliers")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var idParam = new SqlParameter("@SupplierID", id);
            var suppliers = await _context.Suppliers
                .FromSqlRaw("EXEC sp_GetSupplierById @SupplierID", idParam)
                .ToListAsync();

            var supplier = suppliers.FirstOrDefault();
            if (supplier == null) return NotFound();
            return supplier;
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            var p1 = new SqlParameter("@SupplierName", supplier.SupplierName);
            var p2 = new SqlParameter("@ContactEmail", (object?)supplier.ContactEmail ?? DBNull.Value);
            var p3 = new SqlParameter("@CompanyID", supplier.CompanyID);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertSupplier @SupplierName, @ContactEmail, @CompanyID",
                p1, p2, p3);

            return Ok(supplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        {
            if (id != supplier.SupplierID) return BadRequest();

            var p0 = new SqlParameter("@SupplierID", id);
            var p1 = new SqlParameter("@SupplierName", supplier.SupplierName);
            var p2 = new SqlParameter("@ContactEmail", (object?)supplier.ContactEmail ?? DBNull.Value);
            var p3 = new SqlParameter("@CompanyID", supplier.CompanyID);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateSupplier @SupplierID, @SupplierName, @ContactEmail, @CompanyID",
                p0, p1, p2, p3);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var idParam = new SqlParameter("@SupplierID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteSupplier @SupplierID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}