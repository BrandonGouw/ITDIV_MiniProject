// Repositories/UserRepository.cs
using Beliyuk.API.Data;
using Beliyuk.API.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly BelanjaYuk _context;

    public UserRepository(BelanjaYuk context)
    {
        _context = context;
    }

    public async Task<MsUser?> GetByIdAsync(String id)
    {
        return await _context.MsUser
            .Include(u=> u.LtGender).
            FirstOrDefaultAsync(u => u.IdUser == id);
    }

    public async Task<MsUser?> GetByUsernameAsync(string username)
    {
        return await _context.MsUser.FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<MsUser?> GetByEmailAsync(string email)
    {
        return await _context.MsUser.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<MsUser>> GetAllAsync()
    {
        return await _context.MsUser.ToListAsync();
    }

    public async Task<MsUser> CreateAsync(MsUser user)
    {
        _context.MsUser.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateAsync(MsUser user)
    {
        _context.MsUser.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(String id)
    {
        var user = await GetByIdAsync(id);
        if (user != null)
        {
            _context.MsUser.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.MsUser.AnyAsync(u => u.UserName == username);
    }
    
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.MsUser.AnyAsync(u => u.Email == email);
    }

    public Task<bool> PhoneNumberExistsAsync(string phoneNumber)
    {
        return _context.MsUser.AnyAsync(u => u.PhoneNumber == phoneNumber);
    }

    public async Task<MsUser?> GetByCredentialAsync(string credential)
    {
        return await _context.MsUser.FirstOrDefaultAsync(
            u => u.Email.ToLower() == credential.ToLower() || u.PhoneNumber == credential);
    }
    
    public async Task<bool> ExistsByEmailOrPhoneAsync(string email, string phoneNumber)
    {
        return await _context.MsUser.AnyAsync(
            u => u.Email == email || u.PhoneNumber == phoneNumber);
    }

    public async Task<LtGender> GetGenderFromId(String genderId)
    {
        var genderFromId = await _context.LtGenders.FirstOrDefaultAsync(g => g.IdGender == genderId);

        if (genderFromId == null)
        {
            throw new KeyNotFoundException("Gender is not found");
        }
        
        return genderFromId;
    }
}