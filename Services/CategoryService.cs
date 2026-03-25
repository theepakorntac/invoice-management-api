using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.FromSqlRaw("EXEC sp_GetAllCategories").ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@CategoryID", id);
            var result = await _context.Categories
                .FromSqlRaw("EXEC sp_GetCategoryById @CategoryID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(Category category)
        {
            var p1 = new SqlParameter("@CategoryName", category.CategoryName);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertCategory @CategoryName", p1);
        }

        public async Task<int> UpdateAsync(int id, Category category)
        {
            var p0 = new SqlParameter("@CategoryID", id);
            var p1 = new SqlParameter("@CategoryName", category.CategoryName);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateCategory @CategoryID, @CategoryName", p0, p1);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@CategoryID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteCategory @CategoryID", idParam);
        }
    }
}