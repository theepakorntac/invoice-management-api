using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<int> CreateAsync(Customer customer);
        Task<int> UpdateAsync(int id, Customer customer);
        Task<int> DeleteAsync(int id);
    }
}