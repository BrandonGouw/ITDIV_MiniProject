using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beliyuk.API.Models;

public class MsUserSeller
{
    [Key]
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdUserSeller { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdUser { get; set; }
    
    [ForeignKey(nameof(IdUser))]
    public virtual MsUser User { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public String SellerName { get; set; }
    
    [Required]
    [StringLength(1000)]
    [Column(TypeName = "nvarchar(1000)")]
    public String SellerDesc { get; set; }
    
    [Required]
    [StringLength(500)]
    [Column(TypeName = "nvarchar(500)")]
    public String Address { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public String SellerCode { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column(TypeName = "nvarchar(50)")]
    public String PhoneNumber { get; set; }
    
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
    
    public ICollection<MsProduct> Products { get; set; } = new List<MsProduct>();
}