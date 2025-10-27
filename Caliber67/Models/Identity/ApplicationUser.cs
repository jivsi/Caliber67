using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Caliber67.Models.ShoppingCart;
using Caliber67.Models.Orders;

namespace Caliber67.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]  // Changed from [Required]
        [PersonalData]
        public string? FirstName { get; set; }  // Added ? to make it nullable

        [StringLength(100)]  // Changed from [Required]
        [PersonalData]
        public string? LastName { get; set; }   // Added ? to make it nullable

        [PersonalData]
        public DateTime? DateOfBirth { get; set; }

        // Firearms-specific fields
        [PersonalData]
        public bool? IsOfLegalAge { get; set; }

        [PersonalData]
        public DateTime? AgeVerifiedAt { get; set; }

        // Address information
        [StringLength(255)]
        [PersonalData]
        public string? Address { get; set; }

        [StringLength(100)]
        [PersonalData]
        public string? City { get; set; }

        [StringLength(50)]
        [PersonalData]
        public string? State { get; set; }

        [StringLength(20)]
        [PersonalData]
        public string? ZipCode { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public string FullName => $"{FirstName} {LastName}";
    }
}