using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Authentication.Refresh.Commands
{
    public class ValidateRefreshToken : ICommand<bool>
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
