using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories
{
    public class UserOrganizationRepository : AssetTrackerRepository<UserOrganization>, IUserOrganisationRepository
    {
        public UserOrganizationRepository(AssetTrackerContext context) : base(context) { }

        public async Task<bool> IsUserAdminInOrganisationAsync(int userId, int organisationId)
        {
            var result = await _context.UserOrganizations
                .AnyAsync(uo => uo.UserId == userId && uo.OrganizationId == organisationId && uo.IsAdmin);

            return result;
        }

        public async Task<bool> IsUserOwnerInOrganisationAsync(int userId, int organisationId)
        {
            var result = await _context.UserOrganizations
                .AnyAsync(uo => uo.UserId == userId && uo.OrganizationId == organisationId && uo.IsOwner);

            return result;
        }

        public async Task<bool> UpdateIsAdminAsync(int userId, int organisationId, bool isAdmin)
        {
            var userOrganisation = await _context.UserOrganizations
                .FirstOrDefaultAsync(uo => uo.UserId == userId && uo.OrganizationId == organisationId);

            if (userOrganisation != null)
            {
                userOrganisation.IsAdmin = isAdmin;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateIsOwnerAsync(int userId, int organisationId, bool isOwner)
        {
            var userOrganisation = await _context.UserOrganizations
                .FirstOrDefaultAsync(uo => uo.UserId == userId && uo.OrganizationId == organisationId);

            if (userOrganisation != null)
            {
                userOrganisation.IsOwner = isOwner;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
