using System.ComponentModel.DataAnnotations;

namespace invoice_management_api.Models
{
    public class ReportProduct
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty; // คือ CompanyName
    }
}