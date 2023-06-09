using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.ResourceValue.Commands
{
    public class GetOrganizationResourceValueHandler : CommandHandler<GetOrganizationResourceValue, double>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public GetOrganizationResourceValueHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public override async Task<double> ExecuteAsync(GetOrganizationResourceValue command, CancellationToken ct = new CancellationToken())
        {
            var result = await _organizationRepository.GetTotalResourceValueOfOrganizationAsync(command.OrganizationId, ct);

            return result;
        }
    }
}
