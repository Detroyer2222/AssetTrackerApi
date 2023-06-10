using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Refresh.Commands
{
    public class ValidateRefreshToken : ICommand<bool>
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
