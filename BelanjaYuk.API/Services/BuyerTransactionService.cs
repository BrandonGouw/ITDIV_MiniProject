using Belanjayuk.API.Data;
using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.DTO.Response;
using Belanjayuk.API.Models.Transaction;
using Belanjayuk.API.Repositories.Interfaces;
using Belanjayuk.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Belanjayuk.API.Services;

public class BuyerTransactionService : IBuyerTransactionService
{
    private readonly IBuyerTransactionRepository _transactionRepository;
    private readonly BelanjaYuk _dbContext;
    
    public BuyerTransactionService(IBuyerTransactionRepository transactionRepository, BelanjaYuk dbContext)
    {
        _transactionRepository = transactionRepository;
        _dbContext = dbContext;
    }
    
    public async Task<BuyerTransactionResponseDto> CreateTransactionAsync(BuyerTransactionRequestDto requestDto)
    {
        var transaction = new TrBuyerTransaction
        {
            IdBuyerTransaction = Guid.NewGuid().ToString(),
            IdUser = requestDto.IdUser,
            IdPayment = requestDto.IdPayment,
            FinalPrice = requestDto.Items.Sum(i => (i.PriceProduct - i.DiscountProduct) * i.Qty),
            Rating = 0,
            RatingComment = string.Empty,
            DateIn = DateTime.UtcNow,
            UserIn = requestDto.IdUser,
            DateUp = DateTime.UtcNow,
            UserUp = requestDto.IdUser,
            IsActive = true
        };
        
        foreach (var item in requestDto.Items)
        {
            var detail = new TrBuyerTransactionDetail
            {
                IdBuyerTransactionDetail = Guid.NewGuid().ToString(),
                IdBuyerTransaction = transaction.IdBuyerTransaction,
                IdProduct = item.IdProduct,
                Qty = item.Qty,
                PriceProduct = item.PriceProduct,
                DiscountProduct = item.DiscountProduct,
                Rating = 0,
                RatingComment = string.Empty,
                DateIn = DateTime.UtcNow,
                UserIn = requestDto.IdUser,
                DateUp = DateTime.UtcNow,
                UserUp = requestDto.IdUser,
                IsActive = true
            };
            
            transaction.Details.Add(detail);
        }
        
        await _transactionRepository.AddTransactionAsync(transaction);
        
        return await GetTransactionByIdAsync(transaction.IdBuyerTransaction);
    }
    
    public async Task<BuyerTransactionResponseDto> GetTransactionByIdAsync(string idTransaction)
    {
        var transaction = await _transactionRepository.GetTransactionByIdAsync(idTransaction);
        
        if (transaction == null)
            throw new Exception("Transaction not found");
        
        return ConvertToResponseDto(transaction);
    }
    
    public async Task<List<BuyerTransactionResponseDto>> GetTransactionsByUserIdAsync(string idUser)
    {
        var transactions = await _transactionRepository.GetTransactionsByUserIdAsync(idUser);
        
        return transactions.Select(t => ConvertToResponseDto(t)).ToList();
    }
    
    public async Task<List<BuyerTransactionResponseDto>> GetAllTransactionsAsync()
    {
        var transactions = await _transactionRepository.GetAllTransactionsAsync();
        
        return transactions.Select(t => ConvertToResponseDto(t)).ToList();
    }
    
    public async Task<bool> UpdateTransactionRatingAsync(string idTransaction, UpdateTransactionRatingRequestDto requestDto)
    {
        var transaction = await _transactionRepository.GetTransactionByIdAsync(idTransaction);
        
        if (transaction == null)
            throw new Exception("Transaction not found");
        
        transaction.Rating = requestDto.Rating;
        transaction.RatingComment = requestDto.RatingComment ?? string.Empty;
        transaction.DateUp = DateTime.UtcNow;
        
        _transactionRepository.UpdateTransactionAsync(transaction);
        await _transactionRepository.SaveChangesAsync();
        
        return true;
    }
    
    public async Task<bool> UpdateTransactionDetailRatingAsync(string idTransactionDetail, UpdateTransactionRatingRequestDto requestDto)
    {
        var detail = await _dbContext.TrBuyerTransactionDetails.FindAsync(idTransactionDetail);
        
        if (detail == null)
            throw new Exception("Transaction detail not found");
        
        detail.Rating = requestDto.Rating;
        detail.RatingComment = requestDto.RatingComment ?? string.Empty;
        detail.DateUp = DateTime.UtcNow;
        
        _dbContext.TrBuyerTransactionDetails.Update(detail);
        await _dbContext.SaveChangesAsync();
        
        return true;
    }
    
    private BuyerTransactionResponseDto ConvertToResponseDto(TrBuyerTransaction transaction)
    {
        return new BuyerTransactionResponseDto
        {
            IdBuyerTransaction = transaction.IdBuyerTransaction,
            IdUser = transaction.IdUser,
            UserName = transaction.User?.UserName ?? string.Empty,
            IdPayment = transaction.IdPayment,
            PaymentName = transaction.Payment?.PaymentName ?? string.Empty,
            FinalPrice = transaction.FinalPrice,
            Rating = transaction.Rating,
            RatingComment = transaction.RatingComment,
            DateIn = transaction.DateIn,
            IsActive = transaction.IsActive,
            Details = transaction.Details?.Select(d => new BuyerTransactionDetailResponseDto
            {
                IdBuyerTransactionDetail = d.IdBuyerTransactionDetail,
                IdBuyerTransaction = d.IdBuyerTransaction,
                IdProduct = d.IdProduct,
                ProductName = d.Product?.ProductName ?? string.Empty,
                Qty = d.Qty,
                PriceProduct = d.PriceProduct,
                DiscountProduct = d.DiscountProduct,
                Rating = d.Rating,
                RatingComment = d.RatingComment,
                DateIn = d.DateIn,
                IsActive = d.IsActive
            }).ToList() ?? new List<BuyerTransactionDetailResponseDto>()
        };
    }
}
