using System.Reflection.Metadata.Ecma335;
using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;
using Microsoft.Identity.Client;

namespace User.Admin
{
    public static class Data
    {

    }

    public class UpdateOrganisationAcces : ICommand<Response>
    {
        public int UserId { get; set; }
        public int OrganisationId { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UpdateUserOrganisationAccessHandler : CommandHandler<UpdateOrganisationAcces, Response>
    {
        private IUserOrganisationRepository _userOrganisationRepository;

        public UpdateUserOrganisationAccessHandler(IUserOrganisationRepository userOrganisationRepository)
        {
            _userOrganisationRepository = userOrganisationRepository;
        }

        public override async Task<Response> ExecuteAsync(UpdateOrganisationAcces command, CancellationToken ct = new CancellationToken())
        {
            var result =
                await _userOrganisationRepository.UpdateIsAdminAsync(command.UserId, command.OrganisationId,
                    command.IsAdmin);

            return new Response{Success = result};
        }
    }
}