using FastEndpoints;
using GetOrganizationBalance;

namespace AssetTrackerApi.Endpoints.Organization.GetBalance
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("/organization/balance");
            Summary(s =>
            {
                s.Description = "Get the balance(UEC) for a complete organization";
            });
            Policies("User");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var result = await new Commands.GetOrganizationBalance
            {
                OrganizationId = r.OrganizationId
            }.ExecuteAsync(c);


            await SendAsync(new Response { OrganizationBalance = result });
        }
    }
}