using invoice_management_api.Interfaces;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{
    private readonly IRegionService _regionService;

    // ฉีด Service เข้ามาแทน DbContext
    public RegionsController(IRegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
    {
        var regions = await _regionService.GetAllAsync();
        return Ok(regions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Region>> GetRegion(int id)
    {
        var region = await _regionService.GetByIdAsync(id);
        if (region == null) return NotFound();
        return Ok(region);
    }

    [HttpPost]
    public async Task<ActionResult> PostRegion(Region region)
    {
        await _regionService.CreateAsync(region);
        return Ok(region);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutRegion(int id, Region region)
    {
        var rowsAffected = await _regionService.UpdateAsync(id, region);
        if (rowsAffected == 0) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRegion(int id)
    {
        var rowsAffected = await _regionService.DeleteAsync(id);
        if (rowsAffected == 0) return NotFound();
        return NoContent();
    }
}