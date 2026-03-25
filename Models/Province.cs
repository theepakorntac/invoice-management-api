using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvoiceManagementDB.Models;

public class Province
{
    [Key]
    public int ProvinceID { get; set; }
    [Required, StringLength(100)]
    public string ProvinceName { get; set; } = string.Empty;
    public int RegionID { get; set; }
    [ForeignKey("RegionID")]
    [JsonIgnore]
    public Region? Region { get; set; }
    [JsonIgnore]
    public ICollection<City> Cities { get; set; } = new List<City>();
}