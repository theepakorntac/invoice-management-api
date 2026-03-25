using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CitiesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            return await _context.Cities
                .FromSqlRaw("EXEC sp_GetAllCities")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var idParam = new SqlParameter("@CityID", id);
            var cities = await _context.Cities
                .FromSqlRaw("EXEC sp_GetCityById @CityID", idParam)
                .ToListAsync();

            var city = cities.FirstOrDefault();
            if (city == null) return NotFound();
            return city;
        }

        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            var nameParam = new SqlParameter("@CityName", city.CityName);
            var provinceParam = new SqlParameter("@ProvinceID", city.ProvinceID);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertCity @CityName, @ProvinceID",
                nameParam, provinceParam);

            return Ok(city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.CityID) return BadRequest();

            var idParam = new SqlParameter("@CityID", id);
            var nameParam = new SqlParameter("@CityName", city.CityName);
            var provinceParam = new SqlParameter("@ProvinceID", city.ProvinceID);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateCity @CityID, @CityName, @ProvinceID",
                idParam, nameParam, provinceParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var idParam = new SqlParameter("@CityID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteCity @CityID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}