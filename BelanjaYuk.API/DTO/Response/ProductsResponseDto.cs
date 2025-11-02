namespace Belanjayuk.API.DTO.Response;

public class ProductsResponseDto
{
    public String SellerId { get; set; }
    
    public List<ProductResponseDto> Items { get; set; }
    public int TotalItems { get; set; }
    
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}