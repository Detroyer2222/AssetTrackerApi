using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.GetUsers.Commands
{
    public class GetUsersInOrganizationHandler : CommandHandler<GetUsersInOrganization, List<EntityFramework.Models.User>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public GetUsersInOrganizationHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public override async Task<List<EntityFramework.Models.User>> ExecuteAsync(GetUsersInOrganization command, CancellationToken ct = new CancellationToken())
        {
            var result = await _organizationRepository.GetUsersInOrganizationAsync(command.OrganizationId, ct);

            return result;
        }
    }
}
