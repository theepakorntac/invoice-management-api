using invoice_management_api.DTOs;

namespace invoice_management_api.Services
{
    public interface IRegionService
    {
        Task<List<RegionResponse>> GetAllAsync();
        Task<RegionResponse?> GetByIdAsync(int id);
        Task<int> CreateAsync(RegionCreate req);
        Task<bool> UpdateAsync(int id, RegionUpdate req);
        Task<bool> DeleteAsync(int id);
    }
}
