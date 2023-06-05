using System.ComponentModel.DataAnnotations;

namespace AssetTrackerApi.EntityFramework.Models;

public class Organisation
{
    [Key]
    public int OrganisationId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<UserOrganisation> UserOrganisations { get; set; }

}