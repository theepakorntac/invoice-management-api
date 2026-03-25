using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<int> CreateAsync(Order order);
        Task<int> UpdateStatusAsync(int id, int statusId);
        Task<int> DeleteAsync(int id);
    }
}