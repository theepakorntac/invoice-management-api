namespace invoice_management_api.DTOs;

public class RegionResponse
{
    public int RegionID { get; set; }
    public string RegionName { get; set; } = string.Empty;
}

public class RegionRequest
{
    public string RegionName { get; set; } = string.Empty;
}