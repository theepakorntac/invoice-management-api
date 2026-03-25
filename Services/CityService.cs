using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class CityService : ICityService
    {
        private readonly AppDbContext _context;

        public CityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities.FromSqlRaw("EXEC sp_GetAllCities").ToListAsync();
        }

        public async Task<City?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@CityID", id);
            var result = await _context.Cities
                .FromSqlRaw("EXEC sp_GetCityById @CityID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(City city)
        {
            var p1 = new SqlParameter("@CityName", city.CityName);
            var p2 = new SqlParameter("@ProvinceID", city.ProvinceID);
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertCity @CityName, @ProvinceID", p1, p2);
        }

        public async Task<int> UpdateAsync(int id, City city)
        {
            var p0 = new SqlParameter("@CityID", id);
            var p1 = new SqlParameter("@CityName", city.CityName);
            var p2 = new SqlParameter("@ProvinceID", city.ProvinceID);
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateCity @CityID, @CityName, @ProvinceID", p0, p1, p2);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@CityID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteCity @CityID", idParam);
        }
    }
}