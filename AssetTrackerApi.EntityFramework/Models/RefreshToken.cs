using System.ComponentModel.DataAnnotations;

namespace AssetTrackerApi.EntityFramework.Models
{
    public class RefreshToken
    {
        [Key]
        public int UserId { get; set; }
        public DateTime RefreshTokenExpiryDate { get; set; }
        public string Token { get; set; }
    }
}
