using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities() =>
            Ok(await _cityService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            return city == null ? NotFound() : Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult> PostCity(City city)
        {
            await _cityService.CreateAsync(city);
            return Ok(city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.CityID) return BadRequest();
            var rowsAffected = await _cityService.UpdateAsync(id, city);
            return rowsAffected == 0 ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var rowsAffected = await _cityService.DeleteAsync(id);
            return rowsAffected == 0 ? NotFound() : NoContent();
        }
    }
}