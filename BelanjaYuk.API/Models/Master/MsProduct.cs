using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Belanjayuk.API.Models.LookUpTable;
using Belanjayuk.API.Models.Transaction;

namespace Belanjayuk.API.Models.Master;

public class MsProduct
{
    [Key]
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdProduct { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdUserSeller { get; set; }
    
    [ForeignKey(nameof(IdUserSeller))]
    public virtual MsUserSeller UserSeller { get; set; }
    
    [Required]
    [StringLength(200)]
    [Column(TypeName = "nvarchar(200)")]
    public String ProductName { get; set; }
    
    [Required]
    [StringLength(2000)]
    [Column(TypeName = "nvarchar(2000)")]
    public String ProductDesc { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdCategory { get; set; }
    
    [ForeignKey(nameof(IdCategory))]
    public virtual LtCategory Category { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public Decimal Price { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public Decimal DiscountProduct { get; set; }
    
    [Required]
    public int Qty { get; set; }
    
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
    
    public ICollection<TrProductImages> Images { get; set; } = new List<TrProductImages>();
    public ICollection<TrBuyerCart> Carts { get; set; } = new List<TrBuyerCart>();
    public ICollection<TrBuyerTransactionDetail> TransactionDetails { get; set; } = new List<TrBuyerTransactionDetail>();
    
    
}