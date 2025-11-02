namespace Belanjayuk.API.DTO.Response;

public class SellerResponseDto
{
    public string IdSeller { get; set; }
    public string IdUser { get; set; }
    
    public string SellerName { get; set; }
    public string SellerDescription { get; set; }
    
    public String SellerAddress { get; set; }
    
    public string SellerCode { get; set; }
    public string SellerPhone { get; set; }
    
    public bool isActive { get; set; }
}