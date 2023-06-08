namespace AssetTrackerApi.EntityFramework.Models
{
    public class UserOrganization
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsOwner { get; set; }
    }
}
