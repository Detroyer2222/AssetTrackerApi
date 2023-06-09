﻿using AssetTrackerApi.Endpoints.Organization.ResourceValue.Commands;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.Organization.ResourceValue;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/api/organization/resource-value");
        Claims("User");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var result = await new GetOrganizationResourceValue
        {
            OrganizationId = r.OrganizationId
        }.ExecuteAsync(c);

        await SendAsync(new Response { TotalResourceValue = result });
    }
}