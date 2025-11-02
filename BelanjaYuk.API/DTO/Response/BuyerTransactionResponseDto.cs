namespace Belanjayuk.API.DTO.Response;

public class BuyerTransactionResponseDto
{
    public string IdBuyerTransaction { get; set; }
    public string IdUser { get; set; }
    public string UserName { get; set; }
    public string IdPayment { get; set; }
    public string PaymentName { get; set; }
    public decimal FinalPrice { get; set; }
    public int Rating { get; set; }
    public string RatingComment { get; set; }
    public DateTime DateIn { get; set; }
    public bool IsActive { get; set; }
    public List<BuyerTransactionDetailResponseDto> Details { get; set; }
}
