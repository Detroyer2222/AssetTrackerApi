using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.AddBalance.Commands
{
    public class AddUserBalance : ICommand<long>
    {
        public int UserId { get; set; }
        public long Balance { get; set; }
        public bool IsAdded { get; set; }
    }
}
