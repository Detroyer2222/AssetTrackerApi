using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.GetOrganizations.Commands
{
    public class GetUserOrganizationsHandler : CommandHandler<GetUserOrganizations, List<EntityFramework.Models.Organization>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public GetUserOrganizationsHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public override async Task<List<EntityFramework.Models.Organization>> ExecuteAsync(GetUserOrganizations command, CancellationToken ct = new CancellationToken())
        {
            var result = await _organizationRepository.GetOrganizationsFromUserAsync(command.UserId, ct);

            return result;
        }
    }
}
