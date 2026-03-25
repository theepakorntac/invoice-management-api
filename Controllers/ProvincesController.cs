using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvincesController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Province>>> GetProvinces() =>
            Ok(await _provinceService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Province>> GetProvince(int id)
        {
            var province = await _provinceService.GetByIdAsync(id);
            return province == null ? NotFound() : Ok(province);
        }

        [HttpPost]
        public async Task<ActionResult> PostProvince(Province province)
        {
            await _provinceService.CreateAsync(province);
            return Ok(province);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvince(int id, Province province)
        {
            if (id != province.ProvinceID) return BadRequest();
            var rowsAffected = await _provinceService.UpdateAsync(id, province);
            return rowsAffected == 0 ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            var rowsAffected = await _provinceService.DeleteAsync(id);
            return rowsAffected == 0 ? NotFound() : NoContent();
        }
    }
}