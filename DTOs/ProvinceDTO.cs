namespace invoice_management_api.DTOs;

public class ProvinceResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int RegionId { get; set; }
    public string RegionName { get; set; } = string.Empty;
}

public class ProvinceRequest
{
    public string Name { get; set; } = string.Empty;
    public int RegionId { get; set; }
}
