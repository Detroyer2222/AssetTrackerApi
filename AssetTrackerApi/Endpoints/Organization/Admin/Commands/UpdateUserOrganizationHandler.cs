﻿using AssetTrackerApi.Endpoints.Organization.Admin;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.Admin.Commands;

public class UpdateUserOrganisationAccessHandler : CommandHandler<UpdateOrganisationAccess, Response>
{
    private IUserOrganisationRepository _userOrganisationRepository;

    public UpdateUserOrganisationAccessHandler(IUserOrganisationRepository userOrganisationRepository)
    {
        _userOrganisationRepository = userOrganisationRepository;
    }

    public override async Task<Response> ExecuteAsync(UpdateOrganisationAccess command, CancellationToken ct = new CancellationToken())
    {
        var result =
            await _userOrganisationRepository.UpdateIsAdminAsync(command.UserId, command.OrganisationId,
                command.IsAdmin, ct);

        return new Response { Success = result };
    }
}