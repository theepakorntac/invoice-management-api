using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<int> CreateAsync(Product product);
        Task<int> UpdateAsync(int id, Product product);
        Task<int> DeleteAsync(int id);
    }
}