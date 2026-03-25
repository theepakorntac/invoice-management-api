using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvoiceManagementDB.Models;

public class Supplier
{
    [Key]
    public int SupplierID { get; set; }
    [Required, StringLength(200)]
    public string SupplierName { get; set; } = string.Empty;
    [StringLength(255)]
    public string? ContactEmail { get; set; }
    public int CompanyID { get; set; }
    [ForeignKey("CompanyID")]
    [JsonIgnore]
    public Company? Company { get; set; }
}