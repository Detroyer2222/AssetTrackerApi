using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts
{
    public interface IRefreshTokenRepository : IAssetTrackerRepository<RefreshToken>
    {
        Task<bool> ValidateRefreshTokenAsync(int userId, string refreshToken, CancellationToken ct);
        Task<RefreshToken?> SaveOrUpdate(RefreshToken token, CancellationToken ct);
    }
}
