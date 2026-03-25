using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly AppDbContext _context;
        public OrderItemService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems.FromSqlRaw("EXEC sp_GetAllOrderItems").ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId)
        {
            var idParam = new SqlParameter("@OrderID", orderId);
            return await _context.OrderItems
                .FromSqlRaw("EXEC sp_GetOrderItemsByOrderId @OrderID", idParam)
                .ToListAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@OrderItemID", id);
            var result = await _context.OrderItems
                .FromSqlRaw("EXEC sp_GetOrderItemById @OrderItemID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(OrderItem item)
        {
            var p1 = new SqlParameter("@OrderID", item.OrderID);
            var p2 = new SqlParameter("@ProductID", item.ProductID);
            var p3 = new SqlParameter("@Quantity", item.Quantity);
            var p4 = new SqlParameter("@UnitPrice", item.UnitPrice);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertOrderItem @OrderID, @ProductID, @Quantity, @UnitPrice",
                p1, p2, p3, p4);
        }

        public async Task<int> UpdateAsync(int id, OrderItem item)
        {
            var p0 = new SqlParameter("@OrderItemID", id);
            var p1 = new SqlParameter("@OrderID", item.OrderID);
            var p2 = new SqlParameter("@ProductID", item.ProductID);
            var p3 = new SqlParameter("@Quantity", item.Quantity);
            var p4 = new SqlParameter("@UnitPrice", item.UnitPrice);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateOrderItem @OrderItemID, @OrderID, @ProductID, @Quantity, @UnitPrice",
                p0, p1, p2, p3, p4);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@OrderItemID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteOrderItem @OrderItemID", idParam);
        }
    }
}