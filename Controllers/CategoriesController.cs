using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories
                .FromSqlRaw("EXEC sp_GetAllCategories")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var idParam = new SqlParameter("@CategoryID", id);
            var categories = await _context.Categories
                .FromSqlRaw("EXEC sp_GetCategoryById @CategoryID", idParam)
                .ToListAsync();

            var category = categories.FirstOrDefault();
            if (category == null) return NotFound();
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var p1 = new SqlParameter("@CategoryName", category.CategoryName);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertCategory @CategoryName", p1);

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryID) return BadRequest();

            var p0 = new SqlParameter("@CategoryID", id);
            var p1 = new SqlParameter("@CategoryName", category.CategoryName);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateCategory @CategoryID, @CategoryName",
                p0, p1);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var idParam = new SqlParameter("@CategoryID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteCategory @CategoryID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}