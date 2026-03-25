using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementDB.Models;

[Index(nameof(Email), IsUnique = true)]
public class Customer
{
    [Key]
    public int CustomerID { get; set; }
    [Required, StringLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [Required, StringLength(100)]
    public string LastName { get; set; } = string.Empty;
    [Required, StringLength(255)]
    public string Email { get; set; } = string.Empty;
    [StringLength(20)]
    public string? Phone { get; set; }
    public int CityID { get; set; }
    [ForeignKey("CityID")]
    [JsonIgnore]
    public City? City { get; set; }
}