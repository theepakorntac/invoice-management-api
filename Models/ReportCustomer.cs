using System.ComponentModel.DataAnnotations;

namespace invoice_management_api.Models
{
    public class ReportCustomer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string ProvinceName { get; set; } = string.Empty;
        public string RegionName { get; set; } = string.Empty;
    }
}