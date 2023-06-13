using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AssetTrackerApi.EntityFramework.Models;

public class User : IdentityUser
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
#pragma warning disable CS8765
    public override string UserName { get; set; } = null!;


    [Required]
    [MaxLength(100)]
    [DataType(DataType.EmailAddress)]
    public override string Email { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Password)]
    public override string PasswordHash { get; set; } = null!;
#pragma warning restore CS8765
    [Required]
    [MaxLength(128)]
    public string Salt { get; set; } = null!;

    public DateTime SignUpDate { get; set; }
    public DateTime LastLogin { get; set; }

    public long Balance { get; set; }
    public ICollection<UserOrganization> UserOrganizations { get; set; } = null!;
    public ICollection<UserResource> UserResources { get; set; } = null!;
}