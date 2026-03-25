using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                .FromSqlRaw("EXEC sp_GetAllProducts")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var idParam = new SqlParameter("@ProductID", id);
            var products = await _context.Products
                .FromSqlRaw("EXEC sp_GetProductById @ProductID", idParam)
                .ToListAsync();

            var product = products.FirstOrDefault();
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var p1 = new SqlParameter("@ProductName", product.ProductName);
            var p2 = new SqlParameter("@CategoryID", product.CategoryID);
            var p3 = new SqlParameter("@SupplierID", product.SupplierID);
            var p4 = new SqlParameter("@Price", product.Price);
            var p5 = new SqlParameter("@IsActive", product.IsActive);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertProduct @ProductName, @CategoryID, @SupplierID, @Price, @IsActive",
                p1, p2, p3, p4, p5);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID) return BadRequest();

            var p0 = new SqlParameter("@ProductID", id);
            var p1 = new SqlParameter("@ProductName", product.ProductName);
            var p2 = new SqlParameter("@CategoryID", product.CategoryID);
            var p3 = new SqlParameter("@SupplierID", product.SupplierID);
            var p4 = new SqlParameter("@Price", product.Price);
            var p5 = new SqlParameter("@IsActive", product.IsActive);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateProduct @ProductID, @ProductName, @CategoryID, @SupplierID, @Price, @IsActive",
                p0, p1, p2, p3, p4, p5);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var idParam = new SqlParameter("@ProductID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteProduct @ProductID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}