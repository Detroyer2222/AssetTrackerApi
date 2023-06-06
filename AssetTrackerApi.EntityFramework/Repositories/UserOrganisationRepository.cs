using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackerApi.EntityFramework.Models;
using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories
{
    public class UserOrganisationRepository : AssetTrackerRepository<UserOrganisation>, IUserOrganisationRepository
    {
        public UserOrganisationRepository(AssetTrackerContext context) : base(context) { }

        public async Task<bool> IsUserAdminInOrganisationAsync(int userId, int organisationId)
        {
            var result = await _context.UserOrganisations
                .AnyAsync(uo => uo.UserId == userId && uo.OrganisationId == organisationId && uo.IsAdmin);

            return result;
        }
    }
}
