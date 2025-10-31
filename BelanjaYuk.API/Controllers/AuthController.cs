using Beliyuk2.API.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace Beliyuk.API.Controllers;

[Route ("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpGet("ping")]
    public async Task<IActionResult> Ping()
    {
        return StatusCode(200, new { status = "pong" });
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
    {

        try
        {
            var result = await _authService.LoginAsync(loginRequestDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
    {
        try {
            var result = await _authService.RegisterAsync(registerRequestDto);
            return Ok(result);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}