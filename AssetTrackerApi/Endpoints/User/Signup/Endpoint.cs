using AssetTrackerApi.Endpoints.User.Signup.Commands;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using AssetTrackerApi.Tools;
using FastEndpoints;

namespace AssetTrackerApi.Endpoints.User.Signup
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        IUserRepository _userRepository;

        public Endpoint(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override void Configure()
        {
            Post("/user/signup");
            Description(b => b
                .WithGroupName("User"));
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var user = Map.ToEntity(r);


            var result = await new SignupUser
            {
                UserToSignup = user,
                Password = r.Password
            }.ExecuteAsync(c);

            ThrowIfAnyErrors();
            await SendAsync(new()
            {
                UserName = result.UserName,
                Email = result.Email
            });
        }
    }
}