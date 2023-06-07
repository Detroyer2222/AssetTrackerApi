using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IUserRepository : IAssetTrackerRepository<User>
{
    Task<bool> UserExistsAsync(string email);
    Task<User?> GetUserByEmailorUserNameAsync(string emailOrUserName);
    Task<IEnumerable<User>> GetUsersInOrganisationAsync(int organisationId);
    Task<IEnumerable<UserResource>> GetUserResourcesAsync(int userId);

}