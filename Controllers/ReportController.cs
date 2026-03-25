using Microsoft.AspNetCore.Mvc;
using invoice_management_api.Interfaces;
using invoice_management_api.Models;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<ReportCustomer>>> GetCustomerReport()
        {
            var report = await _reportService.GetCustomerDetailsReportAsync();
            return Ok(report);
        }

        [HttpGet("invoices")]
        public async Task<ActionResult<IEnumerable<ReportInvoice>>> GetInvoiceReport()
        {
            var report = await _reportService.GetInvoiceFullReportAsync();
            return Ok(report);
        }

        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<ReportOrder>>> GetOrderReport()
        {
            var report = await _reportService.GetOrderSummaryReportAsync();
            return Ok(report);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ReportProduct>>> GetProductReport()
        {
            var report = await _reportService.GetProductDetailsReportAsync();
            return Ok(report);
        }
    }
}