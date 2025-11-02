using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;
using Belanjayuk.API.Models.Transaction;
using Belanjayuk.API.Repositories.Interfaces;
using Belanjayuk.API.Services.Interfaces;

namespace Belanjayuk.API.Services;

public class BuyerCartService : IBuyerCartService
{
    private readonly IBuyerCartRepository _buyerCartRepository;

    public BuyerCartService(IBuyerCartRepository buyerCartRepository)
    {
        _buyerCartRepository = buyerCartRepository;
    }

    public async Task<bool> AddProductToCartAsync(string idUserBuyer, string idProduct, int quantity) {
        var convertToBuyerCartModel = ConvertToBuyerCartModel(idUserBuyer, idProduct, quantity);

        try {
            await _buyerCartRepository.AddNewCartAsync(convertToBuyerCartModel);
        }
        catch (Exception ex) {
            return false;
        }

        return true;
    }

    public async Task<bool> RemoveProductFromCartAsync(string idBuyerCart) {
        await _buyerCartRepository.RemoveCartAsync(idBuyerCart);
        return true;
    }

    public async Task<bool> UpdateProductQuantityInCartAsync(string idBuyerCart, string idProduct, int newQuantity) {
        var cartByIdBuyerCartAsync = await _buyerCartRepository.GetCartByIdBuyerCartAsync(idBuyerCart);
        if(cartByIdBuyerCartAsync == null) throw new Exception("Buyer cart not found");
        
        cartByIdBuyerCartAsync.Qty = newQuantity;
        _buyerCartRepository.UpdateCartAsync(cartByIdBuyerCartAsync);
        
        return true;
    }

    public async Task<List<BuyerCartResponseDto>> GetBuyerCartByIdUserAsync(string idUserBuyer) {
        var trBuyerCarts = await _buyerCartRepository.GetBuyerCart(idUserBuyer);
        
        List<BuyerCartResponseDto> response = new List<BuyerCartResponseDto>();
        
        trBuyerCarts.ForEach(b =>
        {
            var objProduct = b.Product;
            
            response.Add(new BuyerCartResponseDto
            {
                IdBuyerCart = b.IdBuyerCart,
                IdUser = b.IdUser,
                IdProduct = b.IdProduct,
                ProductName = objProduct != null ? objProduct.ProductName : "",
                ProductDesc = objProduct != null ? objProduct.ProductDesc : "",
                ProductPrice = objProduct != null ? objProduct.Price : 0,
                Qty = b.Qty
            });
        });

        return response;
    }
    
    public async Task<BuyerCartResponseDto> CreateBuyerCartAsync(BuyerCartRequestDto buyerCartRequestDto)
    {
        var entity = ConvertToBuyerCartModel(
            buyerCartRequestDto.IdUserBuyer,
            buyerCartRequestDto.IdProduct,
            buyerCartRequestDto.Qty);
        
        await _buyerCartRepository.AddNewCartAsync(entity);

        return new BuyerCartResponseDto
        {
            IdBuyerCart = entity.IdBuyerCart,
            IdUser = entity.IdUser,
            IdProduct = entity.IdProduct,
            ProductName = string.Empty,
            ProductDesc = string.Empty,
            ProductPrice = 0m,
            Qty = entity.Qty
        };
    }

    private TrBuyerCart ConvertToBuyerCartModel(string idUserBuyer, string idProduct, int quantity)
    {
        return new TrBuyerCart
        {
            IdBuyerCart = Guid.NewGuid().ToString(),
            IdUser = idUserBuyer,
            IdProduct = idProduct,
            Qty = quantity,
            DateIn = DateTime.UtcNow,
            UserIn = idUserBuyer,
            DateUp = DateTime.UtcNow,
            UserUp = idUserBuyer,
            IsActive = true
        };
    }
}