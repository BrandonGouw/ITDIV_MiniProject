namespace Belanjayuk.API.DTO.Response;

public class HomeAddressResponseDto 
{
    public String IdAddress { get; set; }
    public String IdUser { get; set; }
    public string Provinsi { get; set; }
    public string KotaKabupaten { get; set; }
    public string Kecamatan { get; set; }
    public string KodePos { get; set; }
    public string HomeAddressDesc { get; set; }
    public bool IsPrimaryAddress { get; set; }
}