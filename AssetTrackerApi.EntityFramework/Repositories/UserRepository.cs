using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class UserRepository : AssetTrackerRepository<User>, IUserRepository
{
    public UserRepository(AssetTrackerContext context) : base(context)
    {
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        var result = await _context.Users.AnyAsync(u => u.Email == email);
        return result;
    }
}