using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using AssetTrackerApi.Tools;
using FastEndpoints;

namespace User.Signup
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

            bool userExists = await _userRepository.UserExistsAsync(r.Email);

            if (userExists)
            {
                AddError(r => r.Email, "Sorry! E-mail is already in use");
            }

            ThrowIfAnyErrors();

            var passwordSaltPair = PasswordUtility.HashPassword(r.Password);

            user.PasswordHash = passwordSaltPair.Key;
            user.Salt = passwordSaltPair.Value;

            var result = await _userRepository.AddAsync(user);
            if (result is null)
            {
                ThrowError("Sorry! Something went wrong while creating the user");
            }

            await SendAsync(new ()
            {
                UserName = result.UserName,
                Email = result.Email
            });
        }
    }
}