using System.ComponentModel.DataAnnotations;

namespace AssetTrackerApi.EntityFramework.Models;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public double Value { get; set; }

    public ICollection<UserResource> UserResources { get; set; }
}