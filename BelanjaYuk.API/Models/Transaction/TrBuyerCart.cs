using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Belanjayuk.API.Models.Master;

namespace Belanjayuk.API.Models.Transaction;

public class TrBuyerCart
{
    [Key]
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdBuyerCart { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdUser { get; set; }
    
    [ForeignKey(nameof(IdUser))]
    public virtual MsUser User { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdProduct { get; set; }
    
    [ForeignKey(nameof(IdProduct))]
    public virtual MsProduct Product { get; set; }
    
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
}