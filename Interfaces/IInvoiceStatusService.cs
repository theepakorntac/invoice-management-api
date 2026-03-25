using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface IInvoiceStatusService
    {
        Task<IEnumerable<InvoiceStatus>> GetAllAsync();
        Task<InvoiceStatus?> GetByIdAsync(int id);
        Task<int> CreateAsync(InvoiceStatus status);
        Task<int> UpdateAsync(int id, InvoiceStatus status);
        Task<int> DeleteAsync(int id);
    }
}