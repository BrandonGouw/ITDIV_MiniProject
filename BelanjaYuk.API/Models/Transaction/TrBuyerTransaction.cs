using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Belanjayuk.API.Models.LookUpTable;
using Belanjayuk.API.Models.Master;

namespace Belanjayuk.API.Models.Transaction;

public class TrBuyerTransaction
{
    [Key]
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdBuyerTransaction { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdUser { get; set; }
    
    [ForeignKey(nameof(IdUser))]
    public virtual MsUser User { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdPayment { get; set; }
    
    [ForeignKey(nameof(IdPayment))]
    public virtual LtPayment Payment { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public Decimal FinalPrice { get; set; }
    
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
    
    public ICollection<TrBuyerTransactionDetail> Details { get; set; } = new List<TrBuyerTransactionDetail>();
}