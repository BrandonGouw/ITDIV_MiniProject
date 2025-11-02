using Belanjayuk.API.Models.Master;

namespace Belanjayuk.API.Repositories.Interfaces;

public interface ISellerRepository
{
    public Task<bool> IsSellerCodeExistsAsync(string sellerCode);
    public Task<bool> IsSellerNameExistsAsync(string sellerName);
    
    public Task<bool> IsSellerPhoneExistsAsync(string sellerPhone);
    public Task AddNewSellerAsync(MsUserSeller seller);
    public Task<MsUserSeller?> GetSellerByIdUserAsync(string idUser);
    public Task<MsUserSeller?> GetSellerByIdSellerAsync(string idSeller);
}