using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            // ดึงข้อมูลผ่าน Stored Procedure
            return await _context.Orders.FromSqlRaw("EXEC sp_GetAllOrders").ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@OrderID", id);
            var result = await _context.Orders
                .FromSqlRaw("EXEC sp_GetOrderById @OrderID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(Order order)
        {
            var p1 = new SqlParameter("@CustomerID", order.CustomerID);
            var p2 = new SqlParameter("@OrderDate", order.OrderDate);
            var p3 = new SqlParameter("@StatusID", order.StatusID);
            var p4 = new SqlParameter("@TotalAmount", order.TotalAmount);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertOrder @CustomerID, @OrderDate, @StatusID, @TotalAmount",
                p1, p2, p3, p4);
        }

        public async Task<int> UpdateStatusAsync(int id, int statusId)
        {
            var p0 = new SqlParameter("@OrderID", id);
            var p1 = new SqlParameter("@StatusID", statusId);
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateOrderStatus @OrderID, @StatusID", p0, p1);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@OrderID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteOrder @OrderID", idParam);
        }
    }
}