using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceManagementDB.Models;

public class City
{
    [Key]
    public int CityID { get; set; }
    [Required, StringLength(100)]
    public string CityName { get; set; } = string.Empty;
    public int ProvinceID { get; set; }
    [ForeignKey("ProvinceID")]
    public Province? Province { get; set; }
}