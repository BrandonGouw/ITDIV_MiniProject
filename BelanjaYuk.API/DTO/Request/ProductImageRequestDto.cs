using System.ComponentModel.DataAnnotations;

namespace Belanjayuk.API.DTO.Request;

public class ProductImageRequestDto
{
    [Required]
    public string IdProduct { get; set; }
    [Required]
    public string ProductImage { get; set; }
}
