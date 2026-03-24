namespace invoice_management_api.DTOs;

public class RegionResponse
{
    public int RegionID { get; set; }
    public string RegionName { get; set; } = string.Empty;
}

public class RegionUpdate
{
    public string RegionName { get; set; } = string.Empty;
}

public class RegionCreate
{
    public string RegionName { get; set; } = string.Empty;
}

