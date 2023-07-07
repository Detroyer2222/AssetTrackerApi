using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Models.Dto.Balance;
using AssetTrackerApi.EntityFramework.Models.Dto.Resource;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IUserRepository : IAssetTrackerRepository<User>
{
    Task<bool> UserExistsAsync(string email, CancellationToken ct);
    Task<User?> GetUserByEmailAsync(string emailOrUserName, CancellationToken ct);
    Task<long> GetBalance(int userId, CancellationToken ct);
    Task<List<ResourceDto>> GetResourcesAsync(int userId, CancellationToken ct);
    Task<long?> ChangeBalance(int userId, long balance, OperationType operationType, CancellationToken ct);
    Task<bool> ChangeResourcesOfUser(int userId, IEnumerable<ResourceToChangeDto> resources, CancellationToken ct);

}