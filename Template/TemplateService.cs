//using invoice_management_api.DTOs;
//using InvoiceManagementDB;
//using InvoiceManagementDB.Models;
//using Microsoft.EntityFrameworkCore;

//namespace invoice_management_api.Services
//{
//    public class TemplateService : ITemplateService
//    {
//        private readonly AppDbContext _context;

//        public TemplateService(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<RegionResponse>> GetAllAsync()
//        {
//            return await _context.Regions
//                .Select(r => new RegionResponse
//                {
//                    RegionID = r.RegionID,
//                    RegionName = r.RegionName
//                })
//                .ToListAsync();
//        }

//        public async Task<RegionResponse?> GetByIdAsync(int id)
//        {
//            var r = await _context.Regions.FindAsync(id);
//            if (r == null) return null;

//            return new RegionResponse
//            {
//                RegionID = r.RegionID,
//                RegionName = r.RegionName
//            };
//        }

//        public async Task<int> CreateAsync(RegionCreate req)
//        {
//            Validate(req.RegionName);

//            var region = new Region
//            {
//                RegionName = req.RegionName
//            };

//            _context.Regions.Add(region);
//            await _context.SaveChangesAsync();

//            return region.RegionID;
//        }

//        public async Task<bool> UpdateAsync(int id, RegionUpdate req)
//        {
//            Validate(req.RegionName);

//            var region = await _context.Regions.FindAsync(id);
//            if (region == null) return false;

//            region.RegionName = req.RegionName;

//            await _context.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            var region = await _context.Regions.FindAsync(id);
//            if (region == null) return false;

//            _context.Regions.Remove(region);
//            await _context.SaveChangesAsync();

//            return true;
//        }

//        private void Validate(string name)
//        {
//            if (string.IsNullOrWhiteSpace(name))
//                throw new ArgumentException("Region name is required");
//        }
//    }
//}
