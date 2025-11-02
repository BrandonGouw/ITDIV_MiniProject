using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Belanjayuk.API.Models.Master;

namespace Belanjayuk.API.Models.Transaction;

public class TrHomeAddress
{
    [Key]
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdHomeAddress { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdUser { get; set; }
    
    [ForeignKey(nameof(IdUser))]
    public virtual MsUser User { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public String Provinsi { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public String KotaKabupaten { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public String Kecamatan { get; set; }
    
    [Required]
    [StringLength(10)]
    [Column(TypeName = "nvarchar(10)")]
    public String KodePos { get; set; }
    
    [Required]
    [StringLength(2000)]
    [Column(TypeName = "nvarchar(2000)")]
    public String HomeAddressDesc { get; set; }
    
    [Required]
    public Boolean IsPrimaryAddress { get; set; }
    
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