using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Caliber67.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        [PersonalData]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public DateTime? DateOfBirth { get; set; }

        // Firearms-specific fields (ensure legal compliance)
        [PersonalData]
        public bool? IsOfLegalAge { get; set; }

        [PersonalData]
        public DateTime? AgeVerifiedAt { get; set; }

        // Address information for shipping
        [StringLength(255)]
        [PersonalData]
        public string Address { get; set; }

        [StringLength(100)]
        [PersonalData]
        public string City { get; set; }

        [StringLength(50)]
        [PersonalData]
        public string State { get; set; }

        [StringLength(20)]
        [PersonalData]
        public string ZipCode { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<ShoppingCart.Cart> Carts { get; set; }
        public virtual ICollection<Orders.Order> Orders { get; set; }

        // Helper properties
        public string FullName => $"{FirstName} {LastName}";
    }
}