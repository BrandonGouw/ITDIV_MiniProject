using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;

namespace Belanjayuk.API.Services.Interfaces;

public interface IAddressService
{
    public Task<HomeAddressResponseDto?> GetByUserIdAsync(String userId);
    public Task<HomeAddressResponseDto> CreateAsync(HomeAddressRequestDto address);
    public Task UpdateAsync(HomeAddressResponseDto address);
    public Task DeleteAsync(String addressId);
}