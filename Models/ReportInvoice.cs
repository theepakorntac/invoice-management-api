using System.ComponentModel.DataAnnotations;

namespace invoice_management_api.Models
{
    public class ReportInvoice
    {
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        public string? InvoiceStatus { get; set; }
        public string? CustomerName { get; set; }
        public int OrderID { get; set; }
    }
}