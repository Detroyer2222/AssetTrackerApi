using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Authentication.Refresh.Commands
{
    public class SaveRefreshToken : ICommand<bool>
    {
        public int UserId { get; set; }
        public DateTime RefreshExpiry { get; set; }
        public string RefreshToken { get; set; }
    }
}
