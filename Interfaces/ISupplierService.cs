using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task<int> CreateAsync(Supplier supplier);
        Task<int> UpdateAsync(int id, Supplier supplier);
        Task<int> DeleteAsync(int id);
    }
}