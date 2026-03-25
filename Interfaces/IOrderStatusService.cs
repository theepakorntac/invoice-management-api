using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface IOrderStatusService
    {
        Task<IEnumerable<OrderStatus>> GetAllAsync();
        Task<OrderStatus?> GetByIdAsync(int id);
        Task<int> CreateAsync(OrderStatus status);
        Task<int> UpdateAsync(int id, OrderStatus status);
        Task<int> DeleteAsync(int id);
    }
}