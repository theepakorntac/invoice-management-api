using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.Companies
                .FromSqlRaw("EXEC sp_GetAllCompanies")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var idParam = new SqlParameter("@CompanyID", id);
            var companies = await _context.Companies
                .FromSqlRaw("EXEC sp_GetCompanyById @CompanyID", idParam)
                .ToListAsync();

            var company = companies.FirstOrDefault();
            if (company == null) return NotFound();
            return company;
        }

        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            var p1 = new SqlParameter("@CompanyName", company.CompanyName);
            var p2 = new SqlParameter("@RegistrationNo", (object?)company.RegistrationNo ?? DBNull.Value);
            var p3 = new SqlParameter("@Industry", (object?)company.Industry ?? DBNull.Value);
            var p4 = new SqlParameter("@Country", (object?)company.Country ?? DBNull.Value);
            var p5 = new SqlParameter("@Phone", (object?)company.Phone ?? DBNull.Value);
            var p6 = new SqlParameter("@Email", (object?)company.Email ?? DBNull.Value);
            var p7 = new SqlParameter("@EstablishedYear", (object?)company.EstablishedYear ?? DBNull.Value);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertCompany @CompanyName, @RegistrationNo, @Industry, @Country, @Phone, @Email, @EstablishedYear",
                p1, p2, p3, p4, p5, p6, p7);

            return Ok(company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.CompanyID) return BadRequest();

            var p0 = new SqlParameter("@CompanyID", id);
            var p1 = new SqlParameter("@CompanyName", company.CompanyName);
            var p2 = new SqlParameter("@RegistrationNo", (object?)company.RegistrationNo ?? DBNull.Value);
            var p3 = new SqlParameter("@Industry", (object?)company.Industry ?? DBNull.Value);
            var p4 = new SqlParameter("@Country", (object?)company.Country ?? DBNull.Value);
            var p5 = new SqlParameter("@Phone", (object?)company.Phone ?? DBNull.Value);
            var p6 = new SqlParameter("@Email", (object?)company.Email ?? DBNull.Value);
            var p7 = new SqlParameter("@EstablishedYear", (object?)company.EstablishedYear ?? DBNull.Value);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateCompany @CompanyID, @CompanyName, @RegistrationNo, @Industry, @Country, @Phone, @Email, @EstablishedYear",
                p0, p1, p2, p3, p4, p5, p6, p7);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var idParam = new SqlParameter("@CompanyID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteCompany @CompanyID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}