using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class UserRepository : AssetTrackerRepository<User>, IUserRepository
{
    public UserRepository(AssetTrackerContext context) : base(context)
    {
    }

    public override async Task<User> AddAsync(User entity, CancellationToken ct = default(CancellationToken))
    {
        // Add empty entities to user
        entity.UserOrganizations = new List<UserOrganization>();
        entity.UserResources = new List<UserResource>();
        
        return await base.AddAsync(entity, ct);
    }

    public async Task<bool> UserExistsAsync(string email, CancellationToken ct = default(CancellationToken))
    {
        var result = await _context.Users.AnyAsync(u => u.Email == email, ct);
        return result;
    }

    public async Task<User?> GetUserByEmailorUserNameAsync(string emailOrUserName, CancellationToken ct = default(CancellationToken))
    {
        User? result = await _context.Users.FirstOrDefaultAsync(u => u.Email == emailOrUserName || u.UserName == emailOrUserName, ct);
        return result;
    }

    public async Task<IEnumerable<User>> GetUsersInOrganisationAsync(int organisationId, CancellationToken ct = default(CancellationToken))
    {
        return await _context.UserOrganizations
            .Where(uo => uo.OrganizationId == organisationId)
            .Select(uo => uo.User)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<UserResource>> GetUserResourcesAsync(int userId, CancellationToken ct = default(CancellationToken))
    {
        return await _context.UserResources
            .Where(ur => ur.UserId == userId)
            .ToListAsync(ct);
    }
}