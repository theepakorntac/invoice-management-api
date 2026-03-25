namespace invoice_management_api.Models
{
    public class ReportCustomer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CityName { get; set; }
        public string? ProvinceName { get; set; }
        public string? RegionName { get; set; }
    }
}