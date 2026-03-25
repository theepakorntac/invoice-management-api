using invoice_management_api.Interfaces;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly AppDbContext _context;
        public InvoiceService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _context.Invoices
                .FromSqlRaw("EXEC sp_GetAllInvoices")
                .ToListAsync();
        }

        public async Task<Invoice?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@InvoiceID", id);
            var result = await _context.Invoices
                .FromSqlRaw("EXEC sp_GetInvoiceById @InvoiceID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(Invoice invoice)
        {
            var p1 = new SqlParameter("@OrderID", invoice.OrderID);
            var p2 = new SqlParameter("@InvoiceDate", invoice.InvoiceDate);
            var p3 = new SqlParameter("@DueDate", invoice.DueDate);
            var p4 = new SqlParameter("@PaidDate", (object)invoice.PaidDate ?? DBNull.Value);
            var p5 = new SqlParameter("@InvoiceStatusID", invoice.InvoiceStatusID);
            var p6 = new SqlParameter("@TotalAmount", invoice.TotalAmount);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertInvoice @OrderID, @InvoiceDate, @DueDate, @PaidDate, @InvoiceStatusID, @TotalAmount",
                p1, p2, p3, p4, p5, p6);
        }

        public async Task<int> UpdateAsync(int id, Invoice invoice)
        {
            var p0 = new SqlParameter("@InvoiceID", id);
            var p1 = new SqlParameter("@OrderID", invoice.OrderID);
            var p2 = new SqlParameter("@InvoiceDate", invoice.InvoiceDate);
            var p3 = new SqlParameter("@DueDate", invoice.DueDate);
            var p4 = new SqlParameter("@PaidDate", (object)invoice.PaidDate ?? DBNull.Value);
            var p5 = new SqlParameter("@InvoiceStatusID", invoice.InvoiceStatusID);
            var p6 = new SqlParameter("@TotalAmount", invoice.TotalAmount);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateInvoice @InvoiceID, @OrderID, @InvoiceDate, @DueDate, @PaidDate, @InvoiceStatusID, @TotalAmount",
                p0, p1, p2, p3, p4, p5, p6);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@InvoiceID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteInvoice @InvoiceID", idParam);
        }
    }
}