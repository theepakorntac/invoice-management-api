using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvoiceManagementDB.Models;

public class City
{
    [Key]
    public int CityID { get; set; }
    [Required, StringLength(100)]
    public string CityName { get; set; } = string.Empty;
    public int ProvinceID { get; set; }
    [ForeignKey("ProvinceID")]
    [JsonIgnore]
    public Province? Province { get; set; }
}