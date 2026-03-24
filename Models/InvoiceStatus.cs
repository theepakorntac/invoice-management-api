using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementDB.Models;

[Index(nameof(StatusName), IsUnique = true)]
public class InvoiceStatus
{
    [Key]
    public int InvoiceStatusID { get; set; }
    [Required, StringLength(50)]
    public string StatusName { get; set; } = string.Empty;
}