using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caliber67.Models.Identity;

namespace Caliber67.Models.ShoppingCart
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount => CartItems?.Sum(item => item.Subtotal) ?? 0;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}