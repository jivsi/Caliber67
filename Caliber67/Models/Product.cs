using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caliber67.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } // Main category: Guns, Ammo, Accessories

        [StringLength(50)]
        public string SubCategory { get; set; } // Sub-category: Handgun, Rifle, Shotgun, etc.

        [StringLength(50)]
        public string Caliber { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public int StockQuantity { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public bool IsAvailable => StockQuantity > 0;
    }
}