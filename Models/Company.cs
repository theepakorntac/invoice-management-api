using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementDB.Models;

[Index(nameof(RegistrationNo), IsUnique = true)]
public class Company
{
    [Key]
    public int CompanyID { get; set; }
    [Required, StringLength(200)]
    public string CompanyName { get; set; } = string.Empty;
    [StringLength(50)]
    public string? RegistrationNo { get; set; }
    [StringLength(100)]
    public string? Industry { get; set; }
    [StringLength(100)]
    public string? Country { get; set; }
    [StringLength(20)]
    public string? Phone { get; set; }
    [StringLength(255)]
    public string? Email { get; set; }
    public int? EstablishedYear { get; set; }
}