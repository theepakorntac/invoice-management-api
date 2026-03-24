using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceManagementDB.Models;

public class Order
{
    [Key]
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    [ForeignKey("CustomerID")]
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public int StatusID { get; set; }
    [ForeignKey("StatusID")]
    public OrderStatus? Status { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}