using Belanjayuk.API.Data;
using Belanjayuk.API.Models.Master;
using Belanjayuk.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Belanjayuk.API.Repositories;

public class UserPasswordRepository : IUserPasswordRepository
{

    private readonly BelanjaYuk _context;

    public UserPasswordRepository(BelanjaYuk context)
    {
        _context = context;
    }
    
    public async Task<MsUserPassword> GetActivePasswordByUserIdAsync(String userId)
    {
        var activePassword = await _context.MsUserPasswords
            .FirstOrDefaultAsync(p => p.IdUser == userId && p.IsActive);
        
        if(activePassword == null) throw new InvalidOperationException("Active password not found for the given user ID.");
        
        return activePassword;
    }

    public async Task CreateAsync(MsUserPassword userPassword)
    {
        await _context.MsUserPasswords.AddAsync(userPassword);
        await _context.SaveChangesAsync();
    }
}