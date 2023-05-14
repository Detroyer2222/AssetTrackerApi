using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class WalletRepository : AssetTrackerRepository<Wallet>, IWalletRepository
{
    public WalletRepository(AssetTrackerContext context) : base(context)
    {
    }
}