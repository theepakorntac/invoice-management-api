using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly AppDbContext _context;

        public ProvinceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Province>> GetAllAsync()
        {
            return await _context.Provinces.FromSqlRaw("EXEC sp_GetAllProvinces").ToListAsync();
        }

        public async Task<Province?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@ProvinceID", id);
            var result = await _context.Provinces
                .FromSqlRaw("EXEC sp_GetProvinceById @ProvinceID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(Province province)
        {
            var p1 = new SqlParameter("@ProvinceName", province.ProvinceName);
            var p2 = new SqlParameter("@RegionID", province.RegionID);
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertProvince @ProvinceName, @RegionID", p1, p2);
        }

        public async Task<int> UpdateAsync(int id, Province province)
        {
            var p0 = new SqlParameter("@ProvinceID", id);
            var p1 = new SqlParameter("@ProvinceName", province.ProvinceName);
            var p2 = new SqlParameter("@RegionID", province.RegionID);
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateProvince @ProvinceID, @ProvinceName, @RegionID", p0, p1, p2);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@ProvinceID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteProvince @ProvinceID", idParam);
        }
    }
}