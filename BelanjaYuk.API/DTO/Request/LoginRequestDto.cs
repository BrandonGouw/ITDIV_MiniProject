using System.ComponentModel.DataAnnotations;

namespace Beliyuk2.API.DTO.Request;

public class LoginRequestDto
{
    [Required]
    public String LoginCredential { get; set; }
    [Required]
    public String Password { get; set; }
}