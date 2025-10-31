using System.ComponentModel.DataAnnotations;

namespace Beliyuk2.API.DTO.Request;

public class RegisterRequestDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime DOB { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string IdGender { get; set; }
}