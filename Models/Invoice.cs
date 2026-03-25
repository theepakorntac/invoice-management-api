using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvoiceManagementDB.Models;

public class Invoice
{
    [Key]
    public int InvoiceID { get; set; }
    public int OrderID { get; set; }
    [ForeignKey("OrderID")]
    [JsonIgnore]
    public Order? Order { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaidDate { get; set; }
    public int InvoiceStatusID { get; set; }
    [ForeignKey("InvoiceStatusID")]
    [JsonIgnore]
    public InvoiceStatus? InvoiceStatus { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
}