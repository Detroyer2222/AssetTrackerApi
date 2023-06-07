using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public class WalletRepository : AssetTrackerRepository<Wallet>, IWalletRepository
{
    public WalletRepository(AssetTrackerContext context) : base(context)
    {
    }

    public async Task<double> GetTotalBalanceOfUserAsync(int userId)
    {
        return await _context.Users
            .Where(u => u.UserId == userId)
            .Select(u => u.Wallet.Balance)
            .SingleOrDefaultAsync();
    }
}