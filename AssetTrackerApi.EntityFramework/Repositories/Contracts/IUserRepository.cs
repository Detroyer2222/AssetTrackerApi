using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IUserRepository : IAssetTrackerRepository<User>
{
    Task<bool> UserExistsAsync(string email, CancellationToken ct);
    Task<User?> GetUserByEmailorUserNameAsync(string emailOrUserName, CancellationToken ct);
    Task<IEnumerable<User>> GetUsersInOrganisationAsync(int organisationId, CancellationToken ct);
    Task<IEnumerable<UserResource>> GetUserResourcesAsync(int userId, CancellationToken ct);

}