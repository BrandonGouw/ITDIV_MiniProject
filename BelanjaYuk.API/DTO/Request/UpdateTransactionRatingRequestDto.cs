using System.ComponentModel.DataAnnotations;

namespace Belanjayuk.API.DTO.Request;

public class UpdateTransactionRatingRequestDto
{
    [Required]
    public int Rating { get; set; }
    public string RatingComment { get; set; }
}
