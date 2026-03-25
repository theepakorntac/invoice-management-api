using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice?> GetByIdAsync(int id);
        Task<int> CreateAsync(Invoice invoice);
        Task<int> UpdateAsync(int id, Invoice invoice);
        Task<int> DeleteAsync(int id);
    }
}