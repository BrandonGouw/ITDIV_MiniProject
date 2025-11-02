using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Belanjayuk.API.Controllers;

[ApiController]
[Route("api/buyer-cart")]
public class BuyerCartController : ControllerBase {
    private readonly IBuyerCartService _buyerCartService;

    public BuyerCartController(IBuyerCartService buyerCartService) {
        _buyerCartService = buyerCartService;
    }

    [HttpGet("{buyerId}")]
    public async Task<IActionResult> GetBuyerCartByBuyerId([FromRoute] String buyerId)
    {
        var buyerCart = await _buyerCartService.GetBuyerCartByIdUserAsync(buyerId);
        return new OkObjectResult(buyerCart);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBuyerCart([FromBody] BuyerCartRequestDto buyerCartRequestDto)
    {
        {
            var createdBuyerCart = await _buyerCartService.CreateBuyerCartAsync(buyerCartRequestDto);
            return new OkObjectResult(createdBuyerCart);
        }

    }
}