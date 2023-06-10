using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Refresh.Commands
{
    public class SaveRefreshTokenHandler : CommandHandler<SaveRefreshToken, bool>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public SaveRefreshTokenHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public override async Task<bool> ExecuteAsync(SaveRefreshToken command, CancellationToken ct = new CancellationToken())
        {
            var refreshtoken = new EntityFramework.Models.RefreshToken()
            {
                UserId = command.UserId,
                Token = command.RefreshToken,
                RefreshTokenExpiryDate = command.RefreshExpiry
            };

            var result = await _refreshTokenRepository.SaveOrUpdate(refreshtoken, ct);
            if (result == null)
            {
                ThrowError(command => command.UserId, "Could not save Refresh Token");
                return false;
            }

            return true;
        }
    }
}
