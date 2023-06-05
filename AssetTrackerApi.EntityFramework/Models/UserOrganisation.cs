namespace AssetTrackerApi.EntityFramework.Models
{
    public class UserOrganisation
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }

        public bool IsAdmin { get; set; }
    }
}
