using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beliyuk.API.Models;

public class MsUser
{
    
    [Key]
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdUser { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public String UserName { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public String Email { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column(TypeName = "nvarchar(50)")]
    public String PhoneNumber { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public String FirstName { get; set; }
    
    [Required]
    [StringLength(200)]
    [Column(TypeName = "nvarchar(200)")]
    public String LastName { get; set; }
    
    [Required]
    public DateTime DOB { get; set; }
    
    [Required]
    public DateTime DateIn { get; set; }
    
    public DateTime DateUp { get; set; }
    
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String UserUp { get; set; }
    
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String UserIn { get; set; }
    
    [Required]
    public Boolean IsActive { get; set; }
    
    [Required]
    [StringLength(36)]
    [Column(TypeName = "nvarchar(36)")]
    public String IdGender { get; set; }
    
    [ForeignKey(nameof(IdGender))]
    public virtual LtGender LtGender { get; set; }
    
    public ICollection<TrHomeAddress> Addresses { get; set; } = new List<TrHomeAddress>();
    public ICollection<MsUserPassword> Passwords { get; set; } = new List<MsUserPassword>();
    public ICollection<MsUserSeller> Sellers { get; set; } = new List<MsUserSeller>();
    
}