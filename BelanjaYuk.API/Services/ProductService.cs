using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;
using Belanjayuk.API.Models.Master;
using Belanjayuk.API.Repositories.Interfaces;
using Belanjayuk.API.Services.Interfaces;

namespace Belanjayuk.API.Services;

public class ProductService : IProductService {
    private IProductRepository _productRepo;

    public ProductService(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<ProductResponseDto> GetProductAsync(String productId)
    {
        var product = await _productRepo.GetByIdAsync(productId);

        if (product == null) {
            throw new KeyNotFoundException("Product not found");
        }

        var msProductToDto = MsProductToDto(product);

        return msProductToDto;
    }
    
    public async Task<ProductsResponseDto> GetAllProductsOnPage(ProductRequestDto productRequestDto)
    {
        var pageSize = Math.Max(1, productRequestDto.PageSize);
        var pageNumber = Math.Max(1, productRequestDto.CurrentPage);

        var category = productRequestDto.Category;
        var search = productRequestDto.Search;

        var allProducts = await _productRepo.GetAllProductsAsync();

        if (!string.IsNullOrEmpty(category))
            allProducts = allProducts.Where(p => p.Category?.CategoryName == category);

        if (!string.IsNullOrEmpty(search))
            allProducts = allProducts.Where(p =>
                (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(p.ProductDesc) && p.ProductDesc.Contains(search, StringComparison.OrdinalIgnoreCase))
            );

        var total = allProducts.Count();
        var items = allProducts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(MsProductToDto)
            .ToList();

        return new ProductsResponseDto
        {
            Items = items,
            TotalItems= total,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<IEnumerable<MsProduct>> GetAllProducts()
    {
        return await _productRepo.GetAllProductsAsync();
    }

    public async Task<ProductResponseDto> CreateProductAsync(ProductCreationRequestDto productRequestDto)
    {
        var msProduct = new MsProduct
        {
            IdProduct = Guid.NewGuid().ToString(),
            ProductName = productRequestDto.ProductName,
            ProductDesc = productRequestDto.ProductDesc,
            Price = productRequestDto.Price,
            Qty = productRequestDto.Qty,
            IsActive = true,
            DateIn = DateTime.UtcNow,
            DateUp = DateTime.UtcNow,
            UserIn = "SYSTEM",
            UserUp = "SYSTEM",
            IdCategory = productRequestDto.IdCategory
        };

        await _productRepo.CreateProductAsync(msProduct);
        
        return MsProductToDto(msProduct);
    }


    public ProductResponseDto MsProductToDto(MsProduct product)
    {
        return new ProductResponseDto
        {
            ItemId = product.IdProduct,
            ItemName = product.ProductName,
            Description = product.ProductDesc,
            Price = product.Price,
            Stock = product.Qty,
            Category = product.Category.CategoryName,
            IsActive = product.IsActive
        };
    }
}