using System.ComponentModel.DataAnnotations;

namespace invoice_management_api.Models
{
    public class ReportProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string? CategoryName { get; set; }
        public string? SupplierName { get; set; }
        public string? Manufacturer { get; set; } // จาก comp.CompanyName AS Manufacturer
    }
}