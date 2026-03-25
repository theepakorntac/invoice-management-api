using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<City?> GetByIdAsync(int id);
        Task<int> CreateAsync(City city);
        Task<int> UpdateAsync(int id, City city);
        Task<int> DeleteAsync(int id);
    }
}