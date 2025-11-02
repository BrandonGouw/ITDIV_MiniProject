using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Belanjayuk.API.Controllers;

[ApiController]
[Route("api/product-image")]
public class ProductImageController : ControllerBase
{
    private readonly IProductImageService _productImageService;
    
    public ProductImageController(IProductImageService productImageService)
    {
        _productImageService = productImageService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateProductImage([FromBody] ProductImageRequestDto requestDto)
    {
        try
        {
            var productImage = await _productImageService.CreateProductImageAsync(requestDto);
            return Ok(productImage);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("{productImageId}")]
    public async Task<IActionResult> GetProductImageById([FromRoute] string productImageId)
    {
        try
        {
            var productImage = await _productImageService.GetProductImageByIdAsync(productImageId);
            return Ok(productImage);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("product/{productId}")]
    public async Task<IActionResult> GetProductImagesByProductId([FromRoute] string productId)
    {
        var productImages = await _productImageService.GetProductImagesByProductIdAsync(productId);
        return Ok(productImages);
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllProductImages()
    {
        var productImages = await _productImageService.GetAllProductImagesAsync();
        return Ok(productImages);
    }
    
    [HttpPut("{productImageId}")]
    public async Task<IActionResult> UpdateProductImage([FromRoute] string productImageId, [FromBody] ProductImageRequestDto requestDto)
    {
        try
        {
            var result = await _productImageService.UpdateProductImageAsync(productImageId, requestDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("{productImageId}")]
    public async Task<IActionResult> DeleteProductImage([FromRoute] string productImageId)
    {
        try
        {
            var result = await _productImageService.DeleteProductImageAsync(productImageId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
