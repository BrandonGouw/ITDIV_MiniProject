using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Belanjayuk.API.Controllers;

[ApiController]
[Route("api/buyer-transaction")]
public class BuyerTransactionController : ControllerBase
{
    private readonly IBuyerTransactionService _transactionService;
    
    public BuyerTransactionController(IBuyerTransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateTransaction([FromBody] BuyerTransactionRequestDto requestDto)
    {
        try
        {
            var transaction = await _transactionService.CreateTransactionAsync(requestDto);
            return Ok(transaction);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("{transactionId}")]
    public async Task<IActionResult> GetTransactionById([FromRoute] string transactionId)
    {
        try
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(transactionId);
            return Ok(transaction);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetTransactionsByUserId([FromRoute] string userId)
    {
        var transactions = await _transactionService.GetTransactionsByUserIdAsync(userId);
        return Ok(transactions);
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllTransactions()
    {
        var transactions = await _transactionService.GetAllTransactionsAsync();
        return Ok(transactions);
    }
    
    [HttpPut("{transactionId}/rating")]
    public async Task<IActionResult> UpdateTransactionRating([FromRoute] string transactionId, [FromBody] UpdateTransactionRatingRequestDto requestDto)
    {
        try
        {
            var result = await _transactionService.UpdateTransactionRatingAsync(transactionId, requestDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("detail/{transactionDetailId}/rating")]
    public async Task<IActionResult> UpdateTransactionDetailRating([FromRoute] string transactionDetailId, [FromBody] UpdateTransactionRatingRequestDto requestDto)
    {
        try
        {
            var result = await _transactionService.UpdateTransactionDetailRatingAsync(transactionDetailId, requestDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
