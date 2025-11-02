using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;
using Belanjayuk.API.Models.Transaction;
using Belanjayuk.API.Repositories.Interfaces;
using Belanjayuk.API.Services.Interfaces;

namespace Belanjayuk.API.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<HomeAddressResponseDto?> GetByUserIdAsync(string userId)
    {
        var homeAddress = await  _addressRepository.GetByUserIdAsync(userId);
        if(homeAddress == null) throw new KeyNotFoundException("Address not found");
        return AddressToDto(homeAddress);
    }

    public async Task<HomeAddressResponseDto> CreateAsync(HomeAddressRequestDto address)
    {
        var trHomeAddress = new TrHomeAddress {
            IdHomeAddress = Guid.NewGuid().ToString(),
            IdUser = address.idUser,
            HomeAddressDesc = address.HomeAddressDesc,
            Kecamatan= address.Kecamatan,
            Provinsi = address.Provinsi,
            KodePos = address.KodePos, 
            IsPrimaryAddress = address.IsPrimaryAddress,
            KotaKabupaten = address.KotaKabupaten,
            IsActive = true,
            DateIn = DateTime.UtcNow,
            DateUp = DateTime.UtcNow,
            UserIn = "SYSTEM",
            UserUp = "SYSTEM"
        };
        
        await _addressRepository.CreateAsync(trHomeAddress);
        var addressDto = AddressToDto(trHomeAddress);
        return addressDto;
    }

    public Task UpdateAsync(HomeAddressResponseDto address)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string addressId)
    {
        throw new NotImplementedException();
    }
    
    private HomeAddressResponseDto AddressToDto(TrHomeAddress homeAddress) {
        var addressDto = new HomeAddressResponseDto {
            IdAddress = homeAddress.IdHomeAddress,
            IdUser = homeAddress.IdUser,
            HomeAddressDesc = homeAddress.HomeAddressDesc,
            Kecamatan= homeAddress.Kecamatan,
            Provinsi = homeAddress.Provinsi,
            KodePos = homeAddress.KodePos, 
            IsPrimaryAddress = homeAddress.IsPrimaryAddress,
            KotaKabupaten = homeAddress.KotaKabupaten
        };
        
        return addressDto;
    }
}