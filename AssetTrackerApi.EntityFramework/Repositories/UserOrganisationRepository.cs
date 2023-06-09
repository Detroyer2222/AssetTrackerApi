using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class UserOrganizationRepository : AssetTrackerRepository<UserOrganization>, IUserOrganisationRepository
{
    public UserOrganizationRepository(AssetTrackerContext context) : base(context) { }

    public async Task<bool> IsUserAdminInOrganizationAsync(int userId, int organisationId, CancellationToken ct = default(CancellationToken))
    {
        var result = await _context.UserOrganizations
            .AnyAsync(uo => uo.UserId == userId && uo.OrganizationId == organisationId && uo.IsAdmin, ct);

        return result;
    }

    public async Task<bool> IsUserOwnerInOrganizationAsync(int userId, int organisationId, CancellationToken ct = default(CancellationToken))
    {
        var result = await _context.UserOrganizations
            .AnyAsync(uo => uo.UserId == userId && uo.OrganizationId == organisationId && uo.IsOwner, ct);

        return result;
    }

    public async Task<bool> UpdateIsAdminAsync(int userId, int organisationId, bool isAdmin, CancellationToken ct = default(CancellationToken))
    {
        var userOrganisation = await _context.UserOrganizations
            .FirstOrDefaultAsync(uo => uo.UserId == userId && uo.OrganizationId == organisationId, ct);

        if (userOrganisation != null)
        {
            userOrganisation.IsAdmin = isAdmin;
            await _context.SaveChangesAsync(ct);
            return true;
        }

        return false;
    }

    public async Task<bool> UpdateIsOwnerAsync(int userId, int organisationId, bool isOwner, CancellationToken ct = default(CancellationToken))
    {
        var userOrganisation = await _context.UserOrganizations
            .FirstOrDefaultAsync(uo => uo.UserId == userId && uo.OrganizationId == organisationId, ct);

        if (userOrganisation != null)
        {
            userOrganisation.IsOwner = isOwner;
            await _context.SaveChangesAsync(ct);
            return true;
        }

        return false;
    }
}