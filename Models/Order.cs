using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvoiceManagementDB.Models;

public class Order
{
    [Key]
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    [ForeignKey("CustomerID")]
    [JsonIgnore]
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public int StatusID { get; set; }
    [ForeignKey("StatusID")]
    [JsonIgnore]
    public OrderStatus? Status { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    [JsonIgnore]
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}