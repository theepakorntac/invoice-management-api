using invoice_management_api.Models;
using InvoiceManagementDB.Models;

namespace invoice_management_api.Interfaces
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(int id);
        Task<int> CreateAsync(Region region);
        Task<int> UpdateAsync(int id, Region region);
        Task<int> DeleteAsync(int id);
    }
}