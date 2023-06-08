using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AssetTrackerApi.EntityFramework.Models;

public class User : IdentityUser
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; }

    [Required]
    [MaxLength(128)]
    public string Salt { get; set; }

    public bool IsAdmin { get; set; }

    public DateTime SignUpDate { get; set; }
    public DateTime LastLogin { get; set; }

    public long Balance { get; set; }
    public ICollection<UserOrganization> UserOrganizations { get; set; }
    public ICollection<UserResource> UserResources { get; set; }
}