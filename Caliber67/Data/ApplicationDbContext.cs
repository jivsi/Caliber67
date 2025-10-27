using Caliber67.Models;
using Caliber67.Models.Identity;
using Caliber67.Models.Orders;
using Caliber67.Models.ShoppingCart;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Caliber67.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Products
        public DbSet<Product> Products { get; set; }

        // Shopping Cart
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        // Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // SQLite doesn't support decimal as efficiently, but we'll keep it
            // Configure relationships for Shopping Cart
            builder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Orders
            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed initial products data
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Glock 19 Gen 5",
                    Description = "Compact 9mm pistol, perfect for concealed carry and home defense.",
                    Price = 549.99m,
                    Category = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Glock",
                    StockQuantity = 15,
                    ImageUrl = "/images/glock19.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Smith & Wesson M&P15 Sport II",
                    Description = "Reliable AR-15 platform rifle for sport shooting and home defense.",
                    Price = 799.99m,
                    Category = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Smith & Wesson",
                    StockQuantity = 8,
                    ImageUrl = "/images/mp15.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Remington 870 Express",
                    Description = "Dependable pump-action shotgun for hunting and home security.",
                    Price = 449.99m,
                    Category = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Remington",
                    StockQuantity = 12,
                    ImageUrl = "/images/remington870.jpg"
                }
            );
        }
    }
}