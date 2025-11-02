using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belanjayuk.API.Models.LookUpTable;

public class LtPayment
{
    [Key]
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdPayment { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column(TypeName = "nvarchar(50)")]
    public String PaymentName { get; set; }
    
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