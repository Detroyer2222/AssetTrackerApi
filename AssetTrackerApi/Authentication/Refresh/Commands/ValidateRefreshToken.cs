using FastEndpoints;

namespace AssetTrackerApi.Authentication.Refresh.Commands
{
    public class ValidateRefreshToken : ICommand<bool>
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
