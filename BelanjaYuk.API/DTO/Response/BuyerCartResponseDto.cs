namespace Belanjayuk.API.DTO.Response
{
    public class BuyerCartResponseDto
    {
        public string IdBuyerCart { get; set; }
        public string IdUser { get; set; }

        // Optional display fields populated by service (can be null)
        public string UserName { get; set; }

        public string IdProduct { get; set; }

        // Optional product display fields
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal? ProductPrice { get; set; }

        public int Qty { get; set; }
        public DateTime DateIn { get; set; }
        public string UserIn { get; set; }
        public DateTime DateUp { get; set; }
        public string UserUp { get; set; }
        public bool IsActive { get; set; }
    }
}