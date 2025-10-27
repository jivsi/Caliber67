using System.ComponentModel.DataAnnotations;

namespace Caliber67.Models.Identity
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        // Additional profile information
        public string FirearmsLicenseNumber { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }

        // Preferences
        public bool NewsletterSubscription { get; set; } = true;
        public string PreferredFflDealer { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}