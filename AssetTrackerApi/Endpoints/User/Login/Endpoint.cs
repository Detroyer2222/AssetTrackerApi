using AssetTrackerApi.Tools;
using FastEndpoints;

namespace User.Login
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("user/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            //TODO: Continue here https://fast-endpoints.com/docs/security
            bool authenticated = await new AuthenticatePassword()
            {
                EmailorUserName = r.EmailorUserName,
                Password = r.Password
            }.ExecuteAsync(c);

            string token = null;
            if (authenticated)
            {
                token = await new GetToken()
                {
                    EmailorUserName = r.EmailorUserName
                }.ExecuteAsync(c);
            }

            await SendAsync(new()
            {
                EmailorUserName = r.EmailorUserName,
                Token = token
            });
        }
    }
}