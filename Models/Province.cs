using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceManagementDB.Models;

public class Province
{
    [Key]
    public int ProvinceID { get; set; }
    [Required, StringLength(100)]
    public string ProvinceName { get; set; } = string.Empty;
    public int RegionID { get; set; }
    [ForeignKey("RegionID")]
    public Region? Region { get; set; }
    public ICollection<City> Cities { get; set; } = new List<City>();
}