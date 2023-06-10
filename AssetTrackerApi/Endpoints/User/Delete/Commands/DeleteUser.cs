using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Delete.Commands
{
    public class DeleteUser : ICommand<bool>
    {
        public int UserId { get; set; }
    }
}
