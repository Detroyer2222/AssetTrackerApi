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

    public async Task<User?> GetUserByEmailorUserNameAsync(string emailOrUserName)
    {
        User? result = await _context.Users.FirstOrDefaultAsync(u => u.Email == emailOrUserName || u.UserName == emailOrUserName);
        return result;
    }

    public async Task<IEnumerable<User>> GetUsersInOrganisationAsync(int organisationId)
    {
        return await _context.UserOrganisations
            .Where(uo => uo.OrganisationId == organisationId)
            .Select(uo => uo.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserResource>> GetUserResourcesAsync(int userId)
    {
        return await _context.UserResources
            .Where(ur => ur.UserId == userId)
            .ToListAsync();
    }
}