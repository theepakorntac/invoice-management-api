using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;
        public SupplierService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.FromSqlRaw("EXEC sp_GetAllSuppliers").ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@SupplierID", id);
            var result = await _context.Suppliers
                .FromSqlRaw("EXEC sp_GetSupplierById @SupplierID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(Supplier supplier)
        {
            var p1 = new SqlParameter("@SupplierName", supplier.SupplierName);
            var p2 = new SqlParameter("@ContactEmail", (object?)supplier.ContactEmail ?? DBNull.Value);
            var p3 = new SqlParameter("@CompanyID", supplier.CompanyID);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertSupplier @SupplierName, @ContactEmail, @CompanyID", p1, p2,p3);
        }

        public async Task<int> UpdateAsync(int id, Supplier supplier)
        {
            var p0 = new SqlParameter("@SupplierID", id);
            var p1 = new SqlParameter("@SupplierName", supplier.SupplierName);
            var p2 = new SqlParameter("@ContactEmail", (object?)supplier.ContactEmail ?? DBNull.Value);
            var p3 = new SqlParameter("@CompanyID", supplier.CompanyID);


            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateSupplier @SupplierID, @SupplierName, @ContactEmail, @CompanyID", p0, p1, p2, p3);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@SupplierID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteSupplier @SupplierID", idParam);
        }
    }
}