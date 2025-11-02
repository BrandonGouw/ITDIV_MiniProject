using System.ComponentModel.DataAnnotations;

namespace Belanjayuk.API.DTO.Request;

public class NewSellerRequestDto
{
    [Required]
    public string IdUser { get; set; }
    [Required]
    public string SellerName { get; set; }
    [Required]
    public string SellerDescription { get; set; }
    [Required]
    public string SellerCode { get; set; }
    [Required]
    public string SellerEmail { get; set; }
    [Required]
    public string SellerAddress { get; set; }
    [Required]
    public string SellerPhone { get; set; }
}