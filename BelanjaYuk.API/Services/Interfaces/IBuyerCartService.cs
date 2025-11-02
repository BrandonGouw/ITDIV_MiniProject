using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;

namespace Belanjayuk.API.Services.Interfaces;

public interface IBuyerCartService {
    public Task<bool> AddProductToCartAsync(string idUserBuyer, string idProduct, int quantity);
    public Task<bool> RemoveProductFromCartAsync(String idBuyerCart);
    public Task<bool> UpdateProductQuantityInCartAsync(string idUserBuyer, string idProduct, int newQuantity);
    
    public Task<List<BuyerCartResponseDto>> GetBuyerCartByIdUserAsync(string idUserBuyer);
    
    public Task<BuyerCartResponseDto> CreateBuyerCartAsync(BuyerCartRequestDto buyerCartRequestDto);
}