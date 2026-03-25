using System.ComponentModel.DataAnnotations;

namespace invoice_management_api.Models
{
    public class ReportOrder
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
    }
}