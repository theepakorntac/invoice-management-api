using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.FromSqlRaw("EXEC sp_GetAllCompanies").ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@CompanyID", id);
            var result = await _context.Companies
                .FromSqlRaw("EXEC sp_GetCompanyById @CompanyID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(Company company)
        {
            var p1 = new SqlParameter("@CompanyName", company.CompanyName);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertCompany @CompanyName", p1);
        }

        public async Task<int> UpdateAsync(int id, Company company)
        {
            var p0 = new SqlParameter("@CompanyID", id);
            var p1 = new SqlParameter("@CompanyName", company.CompanyName);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateCompany @CompanyID, @CompanyName", p0, p1);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@CompanyID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteCompany @CompanyID", idParam);
        }
    }
}