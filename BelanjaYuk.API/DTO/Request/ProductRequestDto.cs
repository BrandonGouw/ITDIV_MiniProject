namespace Beliyuk2.API.DTO.Request;

public class ProductRequestDto
{
    public String Category { get; set; }
    public String Search { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    
}