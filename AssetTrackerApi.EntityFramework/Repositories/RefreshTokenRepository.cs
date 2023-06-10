using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AssetTrackerApi.EntityFramework.Repositories
{
    public class RefreshTokenRepository : AssetTrackerRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AssetTrackerContext context) : base(context)
        {
        }

        public async Task<bool> ValidateRefreshTokenAsync(int userId, string refreshToken, CancellationToken ct)
        {
            var savedRefreshToken = await _context.RefreshTokens.FindAsync(userId, ct);

            if (savedRefreshToken == null)
            {
                return false;
            }

            return savedRefreshToken.Token == refreshToken && savedRefreshToken.RefreshTokenExpiryDate > DateTime.UtcNow;
        }

        public async Task<RefreshToken?> SaveOrUpdate(RefreshToken token, CancellationToken ct)
        {
            RefreshToken result;
            var dbToken = await _context.RefreshTokens.FindAsync(token.UserId, ct);
            if (dbToken == null)
            {
                var entityResult = await _context.RefreshTokens.AddAsync(token, ct);
                result = entityResult.Entity;
            }
            else
            {
                dbToken.Token = token.Token;
                dbToken.RefreshTokenExpiryDate = token.RefreshTokenExpiryDate;
                result = await UpdateAsync(dbToken, ct);
            }

            return result;
        }
    }
}
