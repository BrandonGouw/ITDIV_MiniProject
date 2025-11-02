using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Belanjayuk.API.Controllers;

[ApiController]
[Route("api/seller")]
public class SellerController : ControllerBase {
    
    private readonly ISellerService _sellerService;
    
    public SellerController(ISellerService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpGet("{sellerId}")]
    public async Task<IActionResult> GetSellerById([FromRoute] String sellerId) {
        var msUserSeller = await _sellerService.GetSellerByIdSellerAsync(sellerId);
        
        return new OkObjectResult(msUserSeller);
    }
    
    [HttpGet("{sellerId}/products")]
    public async Task<IActionResult> GetSellerByUserId([FromRoute] String sellerId) {
        var productsList = await _sellerService.GetSellerProductByIdSellerAsync(sellerId);
        
        return new OkObjectResult(productsList);
    }

    [HttpPost("add-new-seller")]
    public async Task<IActionResult> AddNewSeller([FromBody] NewSellerRequestDto newSellerRequestDto)
    {
        var newUserSeller = await _sellerService.AddNewSellerAsync(newSellerRequestDto);
        return new OkObjectResult(newUserSeller);
    }
}