using System.ComponentModel.DataAnnotations;

namespace Belanjayuk.API.DTO.Request;

public class BuyerTransactionRequestDto
{
    [Required]
    public string IdUser { get; set; }
    [Required]
    public string IdPayment { get; set; }
    [Required]
    public List<TransactionDetailItemDto> Items { get; set; }
}

public class TransactionDetailItemDto
{
    [Required]
    public string IdProduct { get; set; }
    [Required]
    public int Qty { get; set; }
    [Required]
    public decimal PriceProduct { get; set; }
    [Required]
    public decimal DiscountProduct { get; set; }
}
