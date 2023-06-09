namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IUserOrganisationRepository
{
    Task<bool> IsUserAdminInOrganizationAsync(int userId, int organisationId);
    Task<bool> IsUserOwnerInOrganizationAsync(int userId, int organisationId);
    Task<bool> UpdateIsAdminAsync(int userId, int organisationId, bool isAdmin);
    Task<bool> UpdateIsOwnerAsync(int userId, int organisationId, bool isOwner);
}