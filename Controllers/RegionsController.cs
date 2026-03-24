using invoice_management_api.DTOs;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RegionsController(AppDbContext context) => _context = context;

    // GET: api/Regions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegionResponseDTO>>> GetRegions()
    {
        var regions = await _context.Regions.ToListAsync();

        // Map Model -> ResponseDTO
        return Ok(regions.Select(r => new RegionResponseDTO
        {
            RegionID = r.RegionID,
            RegionName = r.RegionName
        }));
    }

    // POST: api/Regions
    [HttpPost]
    public async Task<ActionResult<RegionResponseDTO>> PostRegion(RegionCreateDTO regionDto)
    {
        // 1. Map CreateDTO -> Model
        var region = new Region
        {
            RegionName = regionDto.RegionName
        };

        _context.Regions.Add(region);
        await _context.SaveChangesAsync();

        // 2. Map Model -> ResponseDTO (เพื่อส่งค่าที่มี ID กลับไปให้ User)
        var response = new RegionResponseDTO
        {
            RegionID = region.RegionID,
            RegionName = region.RegionName
        };

        return CreatedAtAction(nameof(GetRegions), new { id = response.RegionID }, response);
    }
}