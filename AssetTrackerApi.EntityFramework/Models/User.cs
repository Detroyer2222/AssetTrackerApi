using System.ComponentModel.DataAnnotations;

namespace AssetTrackerApi.EntityFramework.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public int OrganisationId { get; set; }
    public Organisation Organisation { get; set; }

    public Wallet Wallet { get; set; }
    public ICollection<UserResource> UserResources { get; set; }
}