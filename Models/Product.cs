using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceManagementDB.Models;

public class Product
{
    [Key]
    public int ProductID { get; set; }
    [Required, StringLength(200)]
    public string ProductName { get; set; } = string.Empty;
    public int CategoryID { get; set; }
    [ForeignKey("CategoryID")]
    public Category? Category { get; set; }
    public int SupplierID { get; set; }
    [ForeignKey("SupplierID")]
    public Supplier? Supplier { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
}