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
        var result = await _context.UserOrganisations
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
}