using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class RegionService : IRegionService
    {
        private readonly AppDbContext _context;

        public RegionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions.FromSqlRaw("EXEC sp_GetAllRegions").ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@RegionID", id);
            var regions = await _context.Regions
                .FromSqlRaw("EXEC sp_GetRegionById @RegionID", idParam)
                .ToListAsync();
            return regions.FirstOrDefault();
        }

        public async Task<int> CreateAsync(Region region)
        {
            var p1 = new SqlParameter("@RegionName", region.RegionName);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertRegion @RegionName", p1);
        }

        public async Task<int> UpdateAsync(int id, Region region)
        {
            var p0 = new SqlParameter("@RegionID", id);
            var p1 = new SqlParameter("@RegionName", region.RegionName);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateRegion @RegionID, @RegionName", p0, p1);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@RegionID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteRegion @RegionID", idParam);
        }
    }
}