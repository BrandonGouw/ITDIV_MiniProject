namespace Belanjayuk.API.DTO.Response;

public class BuyerTransactionDetailResponseDto
{
    public string IdBuyerTransactionDetail { get; set; }
    public string IdBuyerTransaction { get; set; }
    public string IdProduct { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal PriceProduct { get; set; }
    public decimal DiscountProduct { get; set; }
    public int Rating { get; set; }
    public string RatingComment { get; set; }
    public DateTime DateIn { get; set; }
    public bool IsActive { get; set; }
}
