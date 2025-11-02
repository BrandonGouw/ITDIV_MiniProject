using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Belanjayuk.API.Models.Master;

namespace Belanjayuk.API.Models.Transaction;

public class TrBuyerTransactionDetail
{
    [Key]
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdBuyerTransactionDetail { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdBuyerTransaction { get; set; }
    
    [ForeignKey(nameof(IdBuyerTransaction))]
    public virtual TrBuyerTransaction BuyerTransaction { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdProduct { get; set; }
    
    [ForeignKey(nameof(IdProduct))]
    public virtual MsProduct Product { get; set; }
    
    [Required]
    public int Qty { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public Decimal PriceProduct { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public Decimal DiscountProduct { get; set; }
    
    [Required]
    public int Rating { get; set; }
    
    [StringLength(1000)]
    [Column(TypeName = "nvarchar(1000)")]
    public String RatingComment { get; set; }
    
    [Required]
    public DateTime DateIn { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String UserIn { get; set; }
    
    [Required]
    public DateTime DateUp { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String UserUp { get; set; }
    
    [Required]
    public Boolean IsActive { get; set; }
}