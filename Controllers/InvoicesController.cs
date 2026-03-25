using Microsoft.AspNetCore.Mvc;
using invoice_management_api.Interfaces;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoicesController(IInvoiceService invoiceService) => _invoiceService = invoiceService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
            => Ok(await _invoiceService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _invoiceService.GetByIdAsync(id);
            return invoice == null ? NotFound() : Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            await _invoiceService.CreateAsync(invoice);
            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.InvoiceID }, invoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.InvoiceID) return BadRequest("ID Mismatch");
            var result = await _invoiceService.UpdateAsync(id, invoice);
            return result == 0 ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _invoiceService.DeleteAsync(id);
            return result == 0 ? NotFound() : NoContent();
        }
    }
}