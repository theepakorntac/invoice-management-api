using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvoiceManagementDB.Models;

public class OrderItem
{
    [Key]
    public int ItemID { get; set; }
    public int OrderID { get; set; }
    [ForeignKey("OrderID")]
    [JsonIgnore]
    public Order? Order { get; set; }
    public int ProductID { get; set; }
    [ForeignKey("ProductID")]
    [JsonIgnore]
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
}