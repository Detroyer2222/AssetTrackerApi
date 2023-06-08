using System.ComponentModel.DataAnnotations;

namespace AssetTrackerApi.EntityFramework.Models;

public class Organization
{
    [Key]
    public int OrganizationId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<UserOrganization> UserOrganizations { get; set; }

}