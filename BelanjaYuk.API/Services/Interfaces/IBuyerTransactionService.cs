using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;

namespace Belanjayuk.API.Services.Interfaces;

public interface IBuyerTransactionService
{
    public Task<BuyerTransactionResponseDto> CreateTransactionAsync(BuyerTransactionRequestDto requestDto);
    public Task<BuyerTransactionResponseDto> GetTransactionByIdAsync(string idTransaction);
    public Task<List<BuyerTransactionResponseDto>> GetTransactionsByUserIdAsync(string idUser);
    public Task<List<BuyerTransactionResponseDto>> GetAllTransactionsAsync();
    public Task<bool> UpdateTransactionRatingAsync(string idTransaction, UpdateTransactionRatingRequestDto requestDto);
    public Task<bool> UpdateTransactionDetailRatingAsync(string idTransactionDetail, UpdateTransactionRatingRequestDto requestDto);
}
