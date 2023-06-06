namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IUserOrganisationRepository
{
    Task<bool> IsUserAdminInOrganisationAsync(int userId, int organisationId);
}