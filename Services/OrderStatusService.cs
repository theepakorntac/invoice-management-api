using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly AppDbContext _context;
        public OrderStatusService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<OrderStatus>> GetAllAsync()
        {
            return await _context.OrderStatuses.FromSqlRaw("EXEC sp_GetAllOrderStatuses").ToListAsync();
        }

        public async Task<OrderStatus?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@StatusID", id);
            var result = await _context.OrderStatuses
                .FromSqlRaw("EXEC sp_GetOrderStatusById @StatusID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(OrderStatus status)
        {
            var p1 = new SqlParameter("@StatusName", status.StatusName);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertOrderStatus @StatusName", p1);
        }

        public async Task<int> UpdateAsync(int id, OrderStatus status)
        {
            var p0 = new SqlParameter("@StatusID", id);
            var p1 = new SqlParameter("@StatusName", status.StatusName);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateOrderStatus @StatusID, @StatusName", p0, p1);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@StatusID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteOrderStatus @StatusID", idParam);
        }
    }
}