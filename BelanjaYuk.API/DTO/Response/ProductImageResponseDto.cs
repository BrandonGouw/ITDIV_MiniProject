namespace Belanjayuk.API.DTO.Response;

public class ProductImageResponseDto
{
    public string IdProductImage { get; set; }
    public string IdProduct { get; set; }
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public DateTime DateIn { get; set; }
    public bool IsActive { get; set; }
}
