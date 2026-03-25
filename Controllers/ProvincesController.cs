using InvoiceManagementDB;
using InvoiceManagementDB.Models; // ตรวจสอบชื่อ Namespace ให้ตรงกับโปรเจกต์คุณ
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProvincesController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET ALL: by SP
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Province>>> GetProvinces()
        {
            return await _context.Provinces
                .FromSqlRaw("EXEC sp_GetAllProvinces")
                .ToListAsync();
        }

        // 2. GET BY ID: by SP
        [HttpGet("{id}")]
        public async Task<ActionResult<Province>> GetProvince(int id)
        {
            var idParam = new SqlParameter("@ProvinceID", id);

            var provinces = await _context.Provinces
                .FromSqlRaw("EXEC sp_GetProvinceById @ProvinceID", idParam)
                .ToListAsync();

            var province = provinces.FirstOrDefault(); 

            if (province == null) return NotFound();
            return province;
        }

        // 3. POST: by SP
        [HttpPost]
        public async Task<ActionResult<Province>> PostProvince(Province province)
        {
            var nameParam = new SqlParameter("@ProvinceName", province.ProvinceName);
            var regionParam = new SqlParameter("@RegionID", province.RegionID);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertProvince @ProvinceName, @RegionID",
                nameParam, regionParam);

            return CreatedAtAction(nameof(GetProvince), new { id = province.ProvinceID }, province);
        }

        // 4. PUT: by SP
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvince(int id, Province province)
        {
            if (id != province.ProvinceID) return BadRequest();

            var idParam = new SqlParameter("@ProvinceID", id);
            var nameParam = new SqlParameter("@ProvinceName", province.ProvinceName);
            var regionParam = new SqlParameter("@RegionID", province.RegionID);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateProvince @ProvinceID, @ProvinceName, @RegionID",
                idParam, nameParam, regionParam);

            if (rowsAffected == 0) return NotFound();

            return NoContent();
        }

        // 5. DELETE: by SP
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            var idParam = new SqlParameter("@ProvinceID", id);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteProvince @ProvinceID", idParam);

            if (rowsAffected == 0) return NotFound();

            return NoContent();
        }
    }
}