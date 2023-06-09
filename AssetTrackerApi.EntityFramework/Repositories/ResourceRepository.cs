using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class ResourceRepository : AssetTrackerRepository<Resource>, IResourceRepository
{
    public ResourceRepository(AssetTrackerContext context) : base(context)
    {
    }

    public async Task<Resource> GetResourceByName(string name, CancellationToken ct = default(CancellationToken))
    {
        var result = await _context.Resources
            .FirstOrDefaultAsync(r => r.Name == name, ct);

        return result;
    }

    public async Task<Resource> GetResourceByCode(string code, CancellationToken ct = default(CancellationToken))
    {
        var result = await _context.Resources
            .FirstOrDefaultAsync(r => r.Code == code, ct);

        return result;
    }
}