namespace Belanjayuk.API.DTO.Request;

public class HomeAddressRequestDto
{
    public String idUser { get; set; }
    public string Provinsi { get; set; }
    public string KotaKabupaten { get; set; }
    public string Kecamatan { get; set; }
    public string KodePos { get; set; }
    public string HomeAddressDesc { get; set; }
    public bool IsPrimaryAddress { get; set; }
}