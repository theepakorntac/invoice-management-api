using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class InvoiceStatusService : IInvoiceStatusService
    {
        private readonly AppDbContext _context;
        public InvoiceStatusService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<InvoiceStatus>> GetAllAsync()
        {
            return await _context.InvoiceStatuses.FromSqlRaw("EXEC sp_GetAllInvoiceStatuses").ToListAsync();
        }

        public async Task<InvoiceStatus?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@StatusID", id);
            var result = await _context.InvoiceStatuses
                .FromSqlRaw("EXEC sp_GetInvoiceStatusById @StatusID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(InvoiceStatus status)
        {
            var p1 = new SqlParameter("@StatusName", status.StatusName);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertInvoiceStatus @StatusName", p1);
        }

        public async Task<int> UpdateAsync(int id, InvoiceStatus status)
        {
            var p0 = new SqlParameter("@StatusID", id);
            var p1 = new SqlParameter("@StatusName", status.StatusName);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateInvoiceStatus @StatusID, @StatusName", p0, p1);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@StatusID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteInvoiceStatus @StatusID", idParam);
        }
    }
}