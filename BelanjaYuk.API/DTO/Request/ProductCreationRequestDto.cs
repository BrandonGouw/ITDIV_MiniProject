namespace Belanjayuk.API.DTO.Request;

public class ProductCreationRequestDto {
    public string IdUserSeller { get; set; }
    public string ProductName { get; set; }
    public string ProductDesc { get; set; }
    public string IdCategory { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountProduct { get; set; }
    public int Qty { get; set; }
}