using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using FastEndpoints.Security;

namespace AssetTrackerApi.Tools
{
    public class TokenUtility
    {
        private IUserOrganisationRepository _userOrganisationRepository;
        private IOrganisationRepository _organisationRepository;

        public TokenUtility(IUserOrganisationRepository userOrganisationRepository, IOrganisationRepository organisationRepository)
        {
            _userOrganisationRepository = userOrganisationRepository;
            _organisationRepository = organisationRepository;
        }

        public async Task<string> CreateToken(EntityFramework.Models.User user, Organisation organisation = null)
        {
            if (organisation == null)
            {
                organisation = await _organisationRepository.GetFirstOrganisationFromUserAsync(user.UserId);
            }

            bool isAdmin = false;
            bool isOwner = false;
            if (organisation != null)
            {
                isAdmin = await _userOrganisationRepository.IsUserAdminInOrganisationAsync(user.UserId, organisation.OrganisationId);
                isOwner = await _userOrganisationRepository.IsUserOwnerInOrganisationAsync(user.UserId, organisation.OrganisationId);
            }


            var jwttoken = JWTBearer.CreateToken(
                signingKey: "SuperLongAndSecureJWTTokenStringThatWillBeReplacedInTheFutureFuckSecurityAndItsAbsurdNeedsOfLoongKeys",// TODO: Get from KeyVault
                expireAt: DateTime.UtcNow.AddDays(1),
                priviledges: u =>
                {
                    if (isAdmin)
                    {
                        u.Roles.Add("Admin");
                    }
                    else if (isOwner)
                    {
                        u.Roles.Add("User");
                    }

                    u.Claims.Add(new("UserName", user.UserName));
                    u.Claims.Add(new("UserId", user.UserId.ToString()));
                    if (organisation != null)
                    {
                        u.Claims.Add(new("OrganisationId", organisation.OrganisationId.ToString()));
                    }
                    else
                    {
                        u.Claims.Add(new("OrganisationId", "NAN"));
                    }                        
                    // TODO: Add more claims here

                });

            return jwttoken;
        }
    }
}
