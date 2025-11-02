using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Belanjayuk.API.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductById([FromRoute] String productId)
    {
        var product = await _productService.GetProductAsync(productId);
        return new OkObjectResult(product);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        return new OkObjectResult(products);
    }

    [HttpPost("all/paged")]
    public async Task<IActionResult> GetAllProductsOnPage([FromBody] ProductRequestDto productRequestDto)
    {
        var products = await _productService.GetAllProductsOnPage(productRequestDto);
        return new OkObjectResult(products);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreationRequestDto productRequestDto)
    {
        var newProduct = await _productService.CreateProductAsync(productRequestDto);
        return new OkObjectResult(newProduct);
    }
}