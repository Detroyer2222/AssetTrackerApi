using System.ComponentModel.DataAnnotations;

namespace AssetTrackerApi.EntityFramework.Models;

public class UserResource
{
    [Key]
    public int UserResourceId { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    public int ResourceId { get; set; }
    public Resource Resource { get; set; }

    [Required]
    public int Quantity { get; set; }
}