namespace Belanjayuk.API.DTO.Response;

public class ProductResponseDto
{
    public string ItemId { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public bool IsActive { get; set; }
}