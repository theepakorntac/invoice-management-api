namespace invoice_management_api.DTOs;

public class RegionResponseDTO
{
    public int RegionID { get; set; }
    public string RegionName { get; set; } = string.Empty;
}

public class RegionCreateDTO
{
    public string RegionName { get; set; } = string.Empty;
}