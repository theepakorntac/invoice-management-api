using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReportCustomer>> GetCustomerDetailsReportAsync()
        {
            // ใช้ FromSqlRaw หรือจะใช้ _context.ReportCustomers.ToListAsync() ก็ได้เพราะเรา Map ToView ไว้แล้ว
            return await _context.ReportCustomers.ToListAsync();
        }

        public async Task<IEnumerable<ReportInvoice>> GetInvoiceFullReportAsync()
        {
            return await _context.ReportInvoices.ToListAsync();
        }

        public async Task<IEnumerable<ReportOrder>> GetOrderSummaryReportAsync()
        {
            // ดึงข้อมูลจาก View v_OrderSummary ผ่าน EF Core
            return await _context.ReportOrders.ToListAsync();
        }

        public async Task<IEnumerable<ReportProduct>> GetProductDetailsReportAsync()
        {
            // ดึงข้อมูลจาก View v_ProductDetails
            return await _context.ReportProducts.ToListAsync();
        }
    }
}