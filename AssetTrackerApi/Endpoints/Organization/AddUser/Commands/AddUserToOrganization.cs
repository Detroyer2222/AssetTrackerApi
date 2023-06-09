using AssetTrackerApi.EntityFramework.Models;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.AddUser.Commands;

public class AddUserToOrganization : ICommand<UserOrganization>
{
    public int UserId { get; set; }
    public int OrganizationId { get; set; }
    public bool IsAdmin { get; set; }
}