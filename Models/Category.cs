using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementDB.Models;

public class Category
{
    [Key]
    public int CategoryID { get; set; }
    [Required, StringLength(100)]
    public string CategoryName { get; set; } = string.Empty;
}