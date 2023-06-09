using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class OrganizationRepository : AssetTrackerRepository<Organization>, IOrganizationRepository
{
    public OrganizationRepository(AssetTrackerContext context) : base(context)
    {
    }

    public async Task<Organization> CreateOrganizationWithOwnerAsync(string organizationName, int ownerId)
    {
        // Create the new organization
        var organization = new Organization
        {
            Name = organizationName
        };

        await _context.Organizations.AddAsync(organization);

        // Create a linking record in the UserOrganization table
        var userOrganization = new UserOrganization
        {
            UserId = ownerId,
            OrganizationId = organization.OrganizationId,
            IsAdmin = true,
            IsOwner = true
        };

        await _context.UserOrganizations.AddAsync(userOrganization);

        // Save changes to the database
        await _context.SaveChangesAsync();

        return organization;
    }

    public async Task AddUserToOrganizationAsync(int userId, int organizationId, bool isAdmin)
    {
        // Create a linking record in the UserOrganization table
        var userOrganization = new UserOrganization
        {
            UserId = userId,
            OrganizationId = organizationId,
            IsAdmin = isAdmin,
            IsOwner = false
        };

        await _context.UserOrganizations.AddAsync(userOrganization);

        // Save changes to the database
        await _context.SaveChangesAsync();
    }

    public async Task<Organization> GetFirstOrganizationFromUserAsync(int userId)
    {
        Organization? result = await _context.UserOrganizations
            .Where(uo => uo.UserId == userId)
            .Select(uo => uo.Organization)
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task<List<Organization>> GetOrganizationsFromUserAsync(int userId)
    {
        var result = await _context.UserOrganizations
            .Where(uo => uo.UserId == userId)
            .Select(uo => uo.Organization)
            .ToListAsync();

        return result;
    }
    public async Task<long> GetOrganizationBalanceAsync(int organisationId)
    {
        return await _context.Users
            .Where(u => u.UserOrganizations.Any(uo => uo.OrganizationId == organisationId))
            .SumAsync(u => u.Balance);
    }

    public async Task<IEnumerable<Resource>> GetOrganizationResourcesAsync(int organisationId)
    {
        return await _context.UserResources
            .Where(ur => ur.User.UserOrganizations.Any(uo => uo.OrganizationId == organisationId))
            .Select(ur => ur.Resource)
            .ToListAsync();
    }

    public async Task<double> GetTotalResourceValueOfOrganizationAsync(int organisationId)
    {
        return await _context.UserResources
            .Where(ur => ur.User.UserOrganizations.Any(uo => uo.OrganizationId == organisationId))
            .SumAsync(ur => ur.Resource.PriceSell * ur.Quantity);
    }
}