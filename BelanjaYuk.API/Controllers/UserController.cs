using Beliyuk.API.Data;
using Beliyuk.API.Models;
using Beliyuk2.API.DTO.Response;
using Beliyuk2.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beliyuk.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly BelanjaYuk _context;

    public UserController(IUserService userService, BelanjaYuk context)
    {
        _userService = userService;
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
}