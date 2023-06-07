using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class OrganisationRepository : AssetTrackerRepository<Organisation>, IOrganisationRepository
{
    public OrganisationRepository(AssetTrackerContext context) : base(context)
    {
    }

    public async Task<Organisation> GetFirstOrganisationFromUserAsync(int userId)
    {
        Organisation? result = await _context.UserOrganisations
            .Where(uo => uo.UserId == userId)
            .Select(uo => uo.Organisation)
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task<List<Organisation>> GetOrganisationsFromUserAsync(int userId)
    {
        var result = await _context.UserOrganisations
            .Where(uo => uo.UserId == userId)
            .Select(uo => uo.Organisation)
            .ToListAsync();

        return result;
    }
    public async Task<long> GetOrganisationBalanceAsync(int organisationId)
    {
        return await _context.Users
            .Where(u => u.UserOrganisations.Any(uo => uo.OrganisationId == organisationId))
            .SumAsync(u => u.Balance);
    }

    public async Task<IEnumerable<Resource>> GetOrganisationResourcesAsync(int organisationId)
    {
        return await _context.UserResources
            .Where(ur => ur.User.UserOrganisations.Any(uo => uo.OrganisationId == organisationId))
            .Select(ur => ur.Resource)
            .ToListAsync();
    }

    public async Task<double> GetTotalResourceValueOfOrganisationAsync(int organisationId)
    {
        return await _context.UserResources
            .Where(ur => ur.User.UserOrganisations.Any(uo => uo.OrganisationId == organisationId))
            .SumAsync(ur => ur.Resource.PriceSell * ur.Quantity);
    }
}