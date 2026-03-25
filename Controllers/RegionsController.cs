using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            return await _context.Regions
                .FromSqlRaw("EXEC sp_GetAllRegions")
                .ToListAsync();
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
            var idParam = new SqlParameter("@RegionID", id);

            var regions = await _context.Regions
                .FromSqlRaw("EXEC sp_GetRegionById @RegionID", idParam)
                .ToListAsync();

            var region = regions.FirstOrDefault();

            if (region == null) return NotFound();
            return region;
        }

        // POST: api/Regions
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            var nameParam = new SqlParameter("@RegionName", region.RegionName);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertRegion @RegionName", nameParam);

            return Ok(region);
        }

        // PUT: api/Regions/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            if (id != region.RegionID) return BadRequest();

            var idParam = new SqlParameter("@RegionID", id);
            var nameParam = new SqlParameter("@RegionName", region.RegionName);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateRegion @RegionID, @RegionName",
                idParam, nameParam);

            if (rowsAffected == 0) return NotFound();

            return NoContent();
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var idParam = new SqlParameter("@RegionID", id);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteRegion @RegionID", idParam);

            if (rowsAffected == 0) return NotFound();

            return NoContent();
        }
    }
}