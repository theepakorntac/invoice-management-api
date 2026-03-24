using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementDB.Models;

public class Region
{
    [Key]
    public int RegionID { get; set; }
    [Required, StringLength(100)]
    public string RegionName { get; set; } = string.Empty;
    public ICollection<Province> Provinces { get; set; } = new List<Province>();
}