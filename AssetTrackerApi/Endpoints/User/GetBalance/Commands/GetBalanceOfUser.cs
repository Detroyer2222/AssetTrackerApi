using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.GetBalance.Commands
{
    public class GetUserBalance : ICommand<long>
    {
        public int UserId { get; set; }
    }
}
