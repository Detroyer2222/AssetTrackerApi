using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
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

    public async Task<long> GetBalance(int userId, CancellationToken ct = default(CancellationToken))
    {
        var result = await _context.Users
            .Where(u => u.UserId == userId)
            .Select(u => u.Balance)
            .FirstOrDefaultAsync(ct);

        return result;
    }

    public async Task<List<ResourceDto>> GetResourcesAsync(int userId, CancellationToken ct = default(CancellationToken))
    {
        var resources = await _context.UserResources
            .Where(ur => ur.UserId == userId)
            .Select(ur => new ResourceDto
            {
                Name = ur.Resource.Name,
                ShortName = ur.Resource.Code,
                Category = ur.Resource.Type,
                Quantity = ur.Quantity,
                PriceSell = ur.Resource.PriceSell,
                PriceBuy = ur.Resource.PriceBuy,
            })
            .ToListAsync();

        return resources;
    }

    public async Task<long?> AddBalance(int userId, long balance, bool isAdded, CancellationToken ct = default(CancellationToken))
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId, ct);

        if (user == null)
        {
            return null;
        }

        if (isAdded)
        {
            user.Balance += balance;
        }
        else
        {
            user.Balance -= balance;
        }

        await _context.SaveChangesAsync(ct);

        return user.Balance;
    }

    public async Task<bool> AddResourcesToUser(int userId, IEnumerable<ResourceToAddDto> resources, CancellationToken ct = default(CancellationToken))
    {
        // Retrieve the user from the database
        var user = await _context.Users.FindAsync(userId, ct);

        // Check if the user exists
        if (user == null)
        {
            return false;
        }

        // Loop through each resource to add
        foreach (var resourceToAdd in resources)
        {
            // Retrieve the resource from the database
            var resource = await _context.Resources.FindAsync(resourceToAdd.ResourceId, ct);

            // Check if the resource exists
            if (resource != null)
            {
                // Check if the user already has this resource
                var userResource = await _context.UserResources
                    .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.ResourceId == resourceToAdd.ResourceId, ct);

                if (userResource != null)
                {
                    // Update the quantity of the existing resource
                    userResource.Quantity += resourceToAdd.Quantity;
                }
                else
                {
                    // Create a new UserResource relationship
                    var newUserResource = new UserResource
                    {
                        UserId = userId,
                        ResourceId = resourceToAdd.ResourceId,
                        Quantity = resourceToAdd.Quantity
                    };

                    // Add the UserResource relationship to the database
                    _context.UserResources.Add(newUserResource);
                }
            }
        }

        // Save the changes to the database
        await _context.SaveChangesAsync(ct);

        return true;
    }

    public async Task<bool> UserExistsAsync(string email, CancellationToken ct = default(CancellationToken))
    {
        var result = await _context.Users.AnyAsync(u => u.Email == email, ct);
        return result;
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken ct = default(CancellationToken))
    {
        User? result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
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