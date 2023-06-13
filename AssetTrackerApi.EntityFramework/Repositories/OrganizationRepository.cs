using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Models.Dto.Resource;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class OrganizationRepository : AssetTrackerRepository<Organization>, IOrganizationRepository
{
    public OrganizationRepository(AssetTrackerContext context) : base(context)
    {
    }

    public async Task<Organization> CreateOrganizationWithOwnerAsync(string organizationName, int ownerId, CancellationToken ct = default)
    {
        // Create the new organization
        var organization = new Organization
        {
            Name = organizationName
        };

        await _context.Organizations.AddAsync(organization, ct);

        // Create a linking record in the UserOrganization table
        var userOrganization = new UserOrganization
        {
            UserId = ownerId,
            OrganizationId = organization.OrganizationId,
            IsAdmin = true,
            IsOwner = true
        };

        await _context.UserOrganizations.AddAsync(userOrganization, ct);

        // Save changes to the database
        await _context.SaveChangesAsync(ct);

        return organization;
    }

    public async Task<UserOrganization> AddUserToOrganizationAsync(int userId, int organizationId, bool isAdmin, CancellationToken ct = default)
    {
        // Create a linking record in the UserOrganization table
        var userOrganization = new UserOrganization
        {
            UserId = userId,
            OrganizationId = organizationId,
            IsAdmin = isAdmin,
            IsOwner = false
        };

        var result= await _context.UserOrganizations.AddAsync(userOrganization, ct);

        // Save changes to the database
        await _context.SaveChangesAsync(ct);

        return result.Entity;
    }

    public async Task<bool> RemoveUserFromOrganizationAsync(int userId, int organizationId, CancellationToken ct)
    {
        var userOrganization = await _context.UserOrganizations
            .FirstOrDefaultAsync(uo => uo.UserId == userId && uo.OrganizationId == organizationId, ct);

        if (userOrganization != null)
        {
            _context.UserOrganizations.Remove(userOrganization);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        return false;
    }

    public async Task<List<User>> GetUsersInOrganizationAsync(int organizationId, CancellationToken ct)
    {
        var result =  await _context.UserOrganizations
            .Where(uo => uo.OrganizationId == organizationId)
            .Select(uo => uo.User)
            .ToListAsync(ct);
        return result;
    }

    public async Task<Organization> GetFirstOrganizationFromUserAsync(int userId, CancellationToken ct = default(CancellationToken))
    {
        Organization? result = await _context.UserOrganizations
            .Where(uo => uo.UserId == userId)
            .Select(uo => uo.Organization)
            .FirstOrDefaultAsync(ct);
        return result;
    }

    public async Task<List<Organization>> GetOrganizationsFromUserAsync(int userId, CancellationToken ct = default(CancellationToken))
    {
        var result = await _context.UserOrganizations
            .Where(uo => uo.UserId == userId)
            .Select(uo => uo.Organization)
            .ToListAsync(ct);

        return result;
    }
    public async Task<long> GetOrganizationBalanceAsync(int organisationId, CancellationToken ct = default(CancellationToken))
    {
        return await _context.Users
            .Where(u => u.UserOrganizations.Any(uo => uo.OrganizationId == organisationId))
            .SumAsync(u => u.Balance, ct);
    }

    public async Task<List<ResourceDto>> GetOrganisationResourcesSummaryAsync(int organisationId, CancellationToken ct = default(CancellationToken))
    {
        return await _context.UserResources
            .Where(ur => ur.User.UserOrganizations.Any(uo => uo.OrganizationId == organisationId))
            .GroupBy(ur => ur.Resource)
            .Select(group => new ResourceDto
            {
                Name = group.Key.Name,
                ShortName = group.Key.Code,
                Category = group.Key.Type,
                Quantity = group.Sum(ur => ur.Quantity),
                TotalValue = group.Sum(ur => (decimal)ur.Resource.PriceSell * ur.Quantity)
            })
            .ToListAsync(ct);
    }

    public async Task<double> GetTotalResourceValueOfOrganizationAsync(int organisationId, CancellationToken ct = default(CancellationToken))
    {
        return await _context.UserResources
            .Where(ur => ur.User.UserOrganizations.Any(uo => uo.OrganizationId == organisationId))
            .SumAsync(ur => ur.Resource.PriceSell * ur.Quantity, ct);
    }
}