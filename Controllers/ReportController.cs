using invoice_management_api.Models;
using InvoiceManagementDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        // 1. รายงานลูกค้าพร้อมที่อยู่ละเอียด (Join 4 ตาราง)
        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<ReportCustomer>>> GetCustomerReport()
        {
            return await _context.ReportCustomers
                .FromSqlRaw("EXEC sp_GetCustomerReport")
                .ToListAsync();
        }

        // 2. รายงานสินค้าพร้อมหมวดหมู่และผู้ผลิต (Join 4 ตาราง)
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ReportProduct>>> GetProductReport()
        {
            return await _context.ReportProducts
                .FromSqlRaw("EXEC sp_GetProductReport")
                .ToListAsync();
        }

        // 3. รายงานสรุปการสั่งซื้อ (Join 3 ตาราง)
        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<ReportOrder>>> GetOrderReport()
        {
            return await _context.ReportOrders
                .FromSqlRaw("EXEC sp_GetOrderReport")
                .ToListAsync();
        }

        // 4. รายงานใบแจ้งหนี้ฉบับเต็ม (ตัวหลักของระบบ Join 4 ตาราง)
        [HttpGet("invoices")]
        public async Task<ActionResult<IEnumerable<ReportInvoice>>> GetInvoiceReport()
        {
            return await _context.ReportInvoices
                .FromSqlRaw("EXEC sp_GetInvoiceReport")
                .ToListAsync();
        }
    }
}