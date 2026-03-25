using System.ComponentModel.DataAnnotations;

namespace invoice_management_api.Models
{
    public class ReportOrder
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? OrderStatus { get; set; } // จาก os.StatusName AS OrderStatus
        public string? CustomerName { get; set; } // จาก c.FirstName + ' ' + c.LastName
    }
}