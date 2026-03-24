using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementDB.Models;

public class OrderStatus
{
    [Key]
    public int StatusID { get; set; }
    [Required, StringLength(50)]
    public string StatusName { get; set; } = string.Empty;
}