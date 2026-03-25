using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(int id);
        Task<int> CreateAsync(Company company);
        Task<int> UpdateAsync(int id, Company company);
        Task<int> DeleteAsync(int id);
    }
}