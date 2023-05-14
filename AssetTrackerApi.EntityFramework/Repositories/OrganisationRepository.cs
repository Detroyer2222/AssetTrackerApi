using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class OrganisationRepository : AssetTrackerRepository<Organisation>, IOrganisationRepository
{
    public OrganisationRepository(AssetTrackerContext context) : base(context)
    {
    }
}