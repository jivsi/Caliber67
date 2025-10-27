using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caliber67.Models.Identity;

namespace Caliber67.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; } = GenerateOrderNumber();

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        // Shipping Information
        [Required]
        [StringLength(100)]
        public string ShippingFirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string ShippingLastName { get; set; }

        [Required]
        [StringLength(255)]
        public string ShippingAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string ShippingCity { get; set; }

        [Required]
        [StringLength(50)]
        public string ShippingState { get; set; }

        [Required]
        [StringLength(20)]
        public string ShippingZipCode { get; set; }

        [Phone]
        public string ShippingPhoneNumber { get; set; }

        [EmailAddress]
        public string ShippingEmail { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        private static string GenerateOrderNumber()
        {
            return $"ORD{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
        }
    }
}