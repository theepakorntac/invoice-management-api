using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.FromSqlRaw("EXEC sp_GetAllProducts").ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@ProductID", id);
            var result = await _context.Products
                .FromSqlRaw("EXEC sp_GetProductById @ProductID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(Product product)
        {
            var p1 = new SqlParameter("@ProductName", product.ProductName);
            var p2 = new SqlParameter("@CategoryID", product.CategoryID);
            var p3 = new SqlParameter("@SupplierID", product.SupplierID);
            var p4 = new SqlParameter("@Price", product.Price);
            var p5 = new SqlParameter("@IsActive", product.IsActive);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertProduct @ProductName, @CategoryID, @SupplierID, @Price, @IsActive",
                p1, p2, p3, p4, p5);
        }

        public async Task<int> UpdateAsync(int id, Product product)
        {
            var p0 = new SqlParameter("@ProductID", id);
            var p1 = new SqlParameter("@ProductName", product.ProductName);
            var p2 = new SqlParameter("@CategoryID", product.CategoryID);
            var p3 = new SqlParameter("@SupplierID", product.SupplierID);
            var p4 = new SqlParameter("@Price", product.Price);
            var p5 = new SqlParameter("@IsActive", product.IsActive);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertProduct @ProductName, @CategoryID, @SupplierID, @Price, @IsActive",
                p1, p2, p3, p4, p5);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@ProductID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteProduct @ProductID", idParam);
        }
    }
}