using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Create.Commands
{
    public class CreateOrganizationHandler : CommandHandler<CreateOrganization, EntityFramework.Models.Organization>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public CreateOrganizationHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public override async Task<EntityFramework.Models.Organization> ExecuteAsync(CreateOrganization command, CancellationToken ct = new CancellationToken())
        {
            var result = await _organizationRepository.CreateOrganizationWithOwnerAsync(command.OrganizationName, command.UserId);
            if (result == null)
                ThrowError(c => c.OrganizationName, "Could not create Organization");

            return result;
        }
    }
}
