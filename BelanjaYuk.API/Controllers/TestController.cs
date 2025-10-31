using System;
using System.Threading.Tasks;
using Beliyuk.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beliyuk.API.Controllers;

[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly BelanjaYuk _dbContext;

    public TestController(BelanjaYuk context)
    {
        _dbContext = context;
    }

    [HttpGet ("db-connection")]
    public async Task<IActionResult> TestMethod()
    {
        try
        {
            var canConnect = await _dbContext.Database.CanConnectAsync();
            if (canConnect)
                return Ok(new { status = "ok", message = "Database connected" });

            return StatusCode(503, new { status = "unavailable", message = "Cannot connect to database" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { status = "error", message = "Exception while checking DB", detail = ex.Message });
        }
    }
    
    [HttpGet("all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _dbContext.MsUser
            .Include(u => u.LtGender)
            .Include(u => u.Passwords)
            .Select(u => new {
                u.IdUser,
                u.UserName,
                u.Email,
                Gender = u.LtGender.GenderName,
                PasswordCount = u.Passwords.Count
            })
            .ToListAsync();
        return Ok(users);
    }
    
    [HttpGet("delete-all-users")]
    public async Task<IActionResult> DeleteAllUsers()
    {
        try
        {
            var users = await _dbContext.MsUser.ToListAsync();
            var passwords = await _dbContext.MsUserPasswords.ToListAsync();
            _dbContext.MsUser.RemoveRange(users);
            _dbContext.MsUserPasswords.RemoveRange(passwords);
            await _dbContext.SaveChangesAsync();
            return Ok(new { status = "ok", message = "All users deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { status = "error", message = "Exception while deleting users", detail = ex.Message });
        }
    }

    [HttpGet("get-genders")]
    public async Task<IActionResult> GetGenders()
    {
        var listAsync = await _dbContext.LtGenders.ToListAsync();
        return Ok(listAsync);
    }
}