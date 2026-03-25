using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceStatusesController : ControllerBase
    {
        private readonly IInvoiceStatusService _statusService;
        public InvoiceStatusesController(IInvoiceStatusService statusService)
            => _statusService = statusService;

        // 1. GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceStatus>>> GetStatuses()
            => Ok(await _statusService.GetAllAsync());

        // 2. GET BY ID (เพิ่มใหม่)
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceStatus>> GetStatus(int id)
        {
            var status = await _statusService.GetByIdAsync(id);
            return status == null ? NotFound() : Ok(status);
        }

        // 3. POST (CREATE)
        [HttpPost]
        public async Task<ActionResult> PostStatus(InvoiceStatus status)
        {
            await _statusService.CreateAsync(status);
            return CreatedAtAction(nameof(GetStatus), new { id = status.InvoiceStatusID }, status);
        }

        // 4. PUT (UPDATE - เพิ่มใหม่)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, InvoiceStatus status)
        {
            // ตรวจสอบว่า ID ใน URL ตรงกับใน Object หรือไม่
            if (id != status.InvoiceStatusID) return BadRequest("ID Mismatch");

            var result = await _statusService.UpdateAsync(id, status);
            return result == 0 ? NotFound() : NoContent();
        }

        // 5. DELETE (เพิ่มใหม่)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var result = await _statusService.DeleteAsync(id);
            return result == 0 ? NotFound() : NoContent();
        }
    }
}