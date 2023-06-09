namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IUserOrganisationRepository
{
    Task<bool> IsUserAdminInOrganizationAsync(int userId, int organisationId, CancellationToken ct);
    Task<bool> IsUserOwnerInOrganizationAsync(int userId, int organisationId, CancellationToken ct);
    Task<bool> UpdateIsAdminAsync(int userId, int organisationId, bool isAdmin, CancellationToken ct);
    Task<bool> UpdateIsOwnerAsync(int userId, int organisationId, bool isOwner, CancellationToken ct);
}