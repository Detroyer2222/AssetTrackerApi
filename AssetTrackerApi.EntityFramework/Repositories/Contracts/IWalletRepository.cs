using AssetTrackerApi.EntityFramework.Models;

namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IWalletRepository : IAssetTrackerRepository<Wallet>
{
    Task<double> GetTotalBalanceOfUserAsync(int userId);

}