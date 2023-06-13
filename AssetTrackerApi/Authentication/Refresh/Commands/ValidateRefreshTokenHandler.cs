using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Authentication.Refresh.Commands
{
    public class ValidateRefreshTokenHandler : CommandHandler<ValidateRefreshToken, bool>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public ValidateRefreshTokenHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public override async Task<bool> ExecuteAsync(ValidateRefreshToken command, CancellationToken ct = new CancellationToken())
        {
            var result = await _refreshTokenRepository.ValidateRefreshTokenAsync(command.UserId, command.RefreshToken, ct);

            return result;
        }
    }
}
