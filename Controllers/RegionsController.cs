using invoice_management_api.DTOs;
using invoice_management_api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly IRegionService _service;

    public RegionsController(IRegionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _service.GetByIdAsync(id);
        if (data == null) return NotFound();

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RegionCreate req)
    {
        try
        {
            var id = await _service.CreateAsync(req);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RegionUpdate req)
    {
        try
        {
            var ok = await _service.UpdateAsync(id, req);
            if (!ok) return NotFound();

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok) return NotFound();

        return NoContent();
    }
}