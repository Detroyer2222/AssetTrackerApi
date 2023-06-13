using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Models.Dto.Resource;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IUserRepository : IAssetTrackerRepository<User>
{
    Task<bool> UserExistsAsync(string email, CancellationToken ct);
    Task<User?> GetUserByEmailorUserNameAsync(string emailOrUserName, CancellationToken ct);
    Task<long> GetBalance(int userId, CancellationToken ct);
    Task<List<ResourceDto>> GetResourcesAsync(int userId, CancellationToken ct);
    Task<long?> AddBalance(int userId, long balance, bool isAdded, CancellationToken ct);
    Task<bool> AddResourcesToUser(int userId, IEnumerable<ResourceToAddDto> resources, CancellationToken ct);

}