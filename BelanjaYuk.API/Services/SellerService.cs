using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;
using Belanjayuk.API.Models.Master;
using Belanjayuk.API.Repositories.Interfaces;
using Belanjayuk.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Belanjayuk.API.Services;

public class SellerService : ISellerService {
    private readonly ISellerRepository _sellerRepository;

    public SellerService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<bool> IsSellerCodeExistsAsync(string sellerCode) {
        return await _sellerRepository.IsSellerCodeExistsAsync(sellerCode);
    }

    public async Task<bool> IsSellerNameExistsAsync(string sellerName) {
        return await _sellerRepository.IsSellerNameExistsAsync(sellerName);
    }

    public async Task<bool> IsSellerPhoneExistsAsync(string sellerPhone) {
        return await _sellerRepository.IsSellerPhoneExistsAsync(sellerPhone);
    }

    public async Task<SellerResponseDto> AddNewSellerAsync(NewSellerRequestDto newSellerRequestDto) {
        var idUser = newSellerRequestDto.IdUser;
        if(idUser == null) throw new SecurityTokenException("User ID is required to create a seller");
        
        if(await IsSellerCodeExistsAsync(newSellerRequestDto.SellerCode))
            throw new ArgumentException("Seller code already exists");
        
        if(await IsSellerNameExistsAsync(newSellerRequestDto.SellerName))
            throw new ArgumentException("Seller name already exists");
        
        if(await IsSellerPhoneExistsAsync(newSellerRequestDto.SellerPhone))
            throw new ArgumentException("Seller phone number already exists");
        

        var newSeller = new MsUserSeller {
            IdUserSeller = Guid.NewGuid().ToString(), 
            IdUser = idUser,
            SellerCode = newSellerRequestDto.SellerCode,
            SellerName = newSellerRequestDto.SellerName,
            SellerDesc = newSellerRequestDto.SellerDescription,
            PhoneNumber = newSellerRequestDto.SellerPhone,
            Address = newSellerRequestDto.SellerAddress,
            
            DateIn = DateTime.UtcNow,
            DateUp = DateTime.UtcNow,
            
            UserIn = "SYSTEM",
            UserUp = "SYSTEM",
            IsActive = true
        };
        
        await _sellerRepository.AddNewSellerAsync(newSeller);
        return MsUserSellerToResponseDto(newSeller);
    }

    public async Task<SellerResponseDto?> GetSellerByIdUserAsync(string idUser)
    {
        var msUserSeller = await _sellerRepository.GetSellerByIdUserAsync(idUser);
        return msUserSeller == null ? throw new KeyNotFoundException("Seller with that user id not found") : MsUserSellerToResponseDto(msUserSeller);
    }

    public async Task<SellerResponseDto?> GetSellerByIdSellerAsync(string idSeller) {
        var msUserSeller =  await _sellerRepository.GetSellerByIdSellerAsync(idSeller);
        return msUserSeller == null ? throw new KeyNotFoundException("Seller with that seller id not found") : MsUserSellerToResponseDto(msUserSeller);
    }

    public async Task<List<ProductResponseDto?>> GetSellerProductByIdSellerAsync(string idSeller)
    {
        var msUserSeller = await _sellerRepository.GetSellerByIdSellerAsync(idSeller);
        
        if(msUserSeller == null) throw new KeyNotFoundException("Seller with that seller id not found");

        var msProducts = msUserSeller.Products;
        var productResponseDtos = new List<ProductResponseDto>();
        foreach (var product in msProducts)
        {
            var productDto = new ProductResponseDto
            {
                ItemId = product.IdProduct,
                ItemName = product.ProductName,
                Description = product.ProductDesc,
                Price = product.Price,
                Stock = product.Qty,
                IsActive = product.IsActive
            };
            productResponseDtos.Add(productDto);
        }
        
        return productResponseDtos;
    }

    private SellerResponseDto MsUserSellerToResponseDto(MsUserSeller seller) {
        return new SellerResponseDto {
            IdSeller = seller.IdUserSeller,
            IdUser = seller.IdUser,
            SellerCode = seller.SellerCode,
            SellerName = seller.SellerName,
            SellerDescription = seller.SellerDesc,
            SellerPhone= seller.PhoneNumber,
            SellerAddress= seller.Address,
            isActive = seller.IsActive
        };
    }
}