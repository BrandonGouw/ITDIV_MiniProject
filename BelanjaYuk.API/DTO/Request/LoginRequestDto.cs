using System.ComponentModel.DataAnnotations;

namespace Belanjayuk.API.DTO.Request;

public class LoginRequestDto
{
    [Required]
    public String LoginCredential { get; set; }
    [Required]
    public String Password { get; set; }
}