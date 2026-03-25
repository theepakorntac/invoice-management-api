using System.ComponentModel.DataAnnotations;

namespace invoice_management_api.Models
{
    public class ReportInvoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal InvoiceTotal { get; set; } // ชื่อต้องตรงกับ Alias ใน View
        public string InvoiceStatus { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public int OrderID { get; set; }
    }
}