using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface IProvinceService
    {
        Task<IEnumerable<Province>> GetAllAsync();
        Task<Province?> GetByIdAsync(int id);
        Task<int> CreateAsync(Province province);
        Task<int> UpdateAsync(int id, Province province);
        Task<int> DeleteAsync(int id);
    }
}