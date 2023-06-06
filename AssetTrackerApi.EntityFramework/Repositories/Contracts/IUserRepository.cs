using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IUserRepository : IAssetTrackerRepository<User>
{
    Task<bool> UserExistsAsync(string email);
    Task<User?> GetUserByEmailorUserNameAsync(string emailOrUserName);
}