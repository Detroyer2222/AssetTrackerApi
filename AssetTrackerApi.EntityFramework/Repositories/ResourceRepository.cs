using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class ResourceRepository : AssetTrackerRepository<Resource>, IResourceRepository
{
    public ResourceRepository(AssetTrackerContext context) : base(context)
    {
    }

    public async Task<Resource> GetResourceByName(string name)
    {
        var result = await _context.Resources
            .FirstOrDefaultAsync(r => r.Name == name);

        return result;
    }

    public async Task<Resource> GetResourceByCode(string code)
    {
        var result = await _context.Resources
            .FirstOrDefaultAsync(r => r.Code == code);

        return result;
    }
}