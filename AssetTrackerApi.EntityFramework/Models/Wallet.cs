using System.ComponentModel.DataAnnotations;

namespace AssetTrackerApi.EntityFramework.Models;

public class Wallet
{
    [Key]
    public int WalletId { get; set; }

    [Required]
    public double Balance { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}