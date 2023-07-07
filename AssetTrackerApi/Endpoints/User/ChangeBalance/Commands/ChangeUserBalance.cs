using AssetTrackerApi.EntityFramework.Models.Dto.Balance;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.ChangeBalance.Commands;

public class ChangeUserBalance : ICommand<long>
{
    public int UserId { get; set; }
    public long Balance { get; set; }
    public OperationType OperationType { get; set; }
}