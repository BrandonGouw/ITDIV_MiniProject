using Belanjayuk.API.Data;
using Belanjayuk.API.DTO.Request;
using Belanjayuk.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Belanjayuk.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAddressService _addressService;
    private readonly BelanjaYuk _context;


    public UserController(IUserService userService, IAddressService addressService, BelanjaYuk context)
    {
        _userService = userService;
        _addressService = addressService;
        _context = context;
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> GetUserProfile()
    {
        return Ok(await _userService.GetCurrentUserAsync());
    }

    [HttpPost("verify-token")]
    public async Task<IActionResult> VerifyToken([FromBody] String token)
    {
        var msUser = await _userService.GetUserFromTokenAsync(token);
        return Ok(msUser);
    }
    
    [HttpPost("post/address")]
    public async Task<IActionResult> PostUserAddress(HomeAddressRequestDto address)
    {
        await _addressService.CreateAsync(address);
        return Ok();
    }
    
    [HttpGet("get/address")]
    public async Task<IActionResult> GetUserAddress([FromQuery] String userId)
    {
        var address = await _addressService.GetByUserIdAsync(userId);
        return Ok(address);
    }
}