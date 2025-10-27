using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Caliber67.Models;
using Caliber67.Models.Identity;
using Caliber67.Models.ShoppingCart;
using Caliber67.Models.Orders;

namespace Caliber67.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

            // ========== SEED DATA - 35 PRODUCTS WITH REAL IMAGES ==========
            builder.Entity<Product>().HasData(
                // ========== HANDGUNS ==========
                new Product
                {
                    Id = 1,
                    Name = "Glock 19 Gen 5",
                    Description = "Compact 9mm pistol, perfect for concealed carry and home defense. Features a modular design and reliable performance.",
                    Price = 549.99m,
                    Category = "Guns",
                    SubCategory = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Glock",
                    StockQuantity = 15,
                    ImageUrl = "https://images.unsplash.com/photo-1595590424281-b0aefc285822?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 2,
                    Name = "Sig Sauer P320 XCompact",
                    Description = "Modular striker-fired pistol with exceptional accuracy and customizable grip modules.",
                    Price = 649.99m,
                    Category = "Guns",
                    SubCategory = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Sig Sauer",
                    StockQuantity = 12,
                    ImageUrl = "https://images.unsplash.com/photo-1595593179760-23fef6a0d95a?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 3,
                    Name = "Smith & Wesson M&P Shield Plus",
                    Description = "Ultra-compact pistol with 13+1 capacity, perfect for everyday concealed carry.",
                    Price = 499.99m,
                    Category = "Guns",
                    SubCategory = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Smith & Wesson",
                    StockQuantity = 20,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 4,
                    Name = "Springfield 1911 Ronin",
                    Description = "Classic 1911 design with modern features, offering exceptional accuracy and smooth operation.",
                    Price = 899.99m,
                    Category = "Guns",
                    SubCategory = "Handgun",
                    Caliber = ".45 ACP",
                    Manufacturer = "Springfield Armory",
                    StockQuantity = 8,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 5,
                    Name = "CZ P-10 C",
                    Description = "Ergonomic striker-fired pistol with excellent trigger and superior ergonomics.",
                    Price = 499.99m,
                    Category = "Guns",
                    SubCategory = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "CZ",
                    StockQuantity = 18,
                    ImageUrl = "https://images.unsplash.com/photo-1595590424281-b0aefc285822?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 6,
                    Name = "Springfield Hellcat Pro",
                    Description = "Micro-compact pistol with 15+1 capacity, perfect for everyday concealed carry.",
                    Price = 599.99m,
                    Category = "Guns",
                    SubCategory = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Springfield Armory",
                    StockQuantity = 22,
                    ImageUrl = "https://images.unsplash.com/photo-1595593179760-23fef6a0d95a?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 7,
                    Name = "FN 509 Tactical",
                    Description = "Duty-grade pistol with suppressor-height sights and threaded barrel.",
                    Price = 899.99m,
                    Category = "Guns",
                    SubCategory = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "FN Herstal",
                    StockQuantity = 6,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 8,
                    Name = "Walther PDP Compact",
                    Description = "Performance Duty Pistol with superior ergonomics and lightning-fast trigger.",
                    Price = 649.99m,
                    Category = "Guns",
                    SubCategory = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Walther",
                    StockQuantity = 10,
                    ImageUrl = "https://images.unsplash.com/photo-1595590424281-b0aefc285822?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== RIFLES ==========
                new Product
                {
                    Id = 9,
                    Name = "Smith & Wesson M&P15 Sport II",
                    Description = "Reliable AR-15 platform rifle for sport shooting, home defense, and tactical applications.",
                    Price = 799.99m,
                    Category = "Guns",
                    SubCategory = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Smith & Wesson",
                    StockQuantity = 10,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 10,
                    Name = "Ruger 10/22 Carbine",
                    Description = "Classic .22 LR rifle perfect for training, plinking, and small game hunting.",
                    Price = 329.99m,
                    Category = "Guns",
                    SubCategory = "Rifle",
                    Caliber = ".22 LR",
                    Manufacturer = "Ruger",
                    StockQuantity = 25,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 11,
                    Name = "Daniel Defense DDM4 V7",
                    Description = "Premium AR-15 with advanced features for serious shooters and professionals.",
                    Price = 1799.99m,
                    Category = "Guns",
                    SubCategory = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Daniel Defense",
                    StockQuantity = 4,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 12,
                    Name = "Springfield Saint Victor",
                    Description = "High-performance AR-15 with enhanced features for competitive shooting.",
                    Price = 1099.99m,
                    Category = "Guns",
                    SubCategory = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Springfield Armory",
                    StockQuantity = 7,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 13,
                    Name = "Ruger AR-556",
                    Description = "Reliable and affordable AR-15 platform rifle made in the USA.",
                    Price = 799.99m,
                    Category = "Guns",
                    SubCategory = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Ruger",
                    StockQuantity = 15,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 14,
                    Name = "Aero Precision AC-15",
                    Description = "Quality-built AR-15 with premium components and excellent accuracy.",
                    Price = 899.99m,
                    Category = "Guns",
                    SubCategory = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Aero Precision",
                    StockQuantity = 8,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== SNIPER RIFLES ==========
                new Product
                {
                    Id = 15,
                    Name = "Remington 700 SPS Tactical",
                    Description = "Bolt-action precision rifle with heavy barrel for long-range accuracy.",
                    Price = 799.99m,
                    Category = "Guns",
                    SubCategory = "Sniper Rifle",
                    Caliber = ".308 Winchester",
                    Manufacturer = "Remington",
                    StockQuantity = 6,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 16,
                    Name = "Ruger Precision Rifle",
                    Description = "Modular bolt-action rifle designed for long-range precision shooting.",
                    Price = 1399.99m,
                    Category = "Guns",
                    SubCategory = "Sniper Rifle",
                    Caliber = "6.5 Creedmoor",
                    Manufacturer = "Ruger",
                    StockQuantity = 3,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 17,
                    Name = "Bergara B-14 HMR",
                    Description = "Hybrid Match Rifle with exceptional out-of-the-box accuracy.",
                    Price = 999.99m,
                    Category = "Guns",
                    SubCategory = "Sniper Rifle",
                    Caliber = ".308 Winchester",
                    Manufacturer = "Bergara",
                    StockQuantity = 5,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 18,
                    Name = "Tikka T3x TAC A1",
                    Description = "Modern tactical chassis rifle with outstanding accuracy and modularity.",
                    Price = 1999.99m,
                    Category = "Guns",
                    SubCategory = "Sniper Rifle",
                    Caliber = "6.5 Creedmoor",
                    Manufacturer = "Tikka",
                    StockQuantity = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 19,
                    Name = "Savage 110 Precision",
                    Description = "Budget-friendly precision rifle with excellent accuracy for the price.",
                    Price = 1199.99m,
                    Category = "Guns",
                    SubCategory = "Sniper Rifle",
                    Caliber = ".308 Winchester",
                    Manufacturer = "Savage",
                    StockQuantity = 7,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== SHOTGUNS ==========
                new Product
                {
                    Id = 20,
                    Name = "Remington 870 Express",
                    Description = "Dependable pump-action shotgun for hunting, home security, and sport shooting.",
                    Price = 449.99m,
                    Category = "Guns",
                    SubCategory = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Remington",
                    StockQuantity = 12,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 21,
                    Name = "Mossberg 500 Security",
                    Description = "Versatile pump-action shotgun designed specifically for home defense applications.",
                    Price = 419.99m,
                    Category = "Guns",
                    SubCategory = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Mossberg",
                    StockQuantity = 15,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 22,
                    Name = "Benelli M4",
                    Description = "Semi-automatic tactical shotgun used by military and law enforcement worldwide.",
                    Price = 1899.99m,
                    Category = "Guns",
                    SubCategory = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Benelli",
                    StockQuantity = 3,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 23,
                    Name = "Winchester SXP Defender",
                    Description = "Fast-action pump shotgun with smooth operation for home defense.",
                    Price = 379.99m,
                    Category = "Guns",
                    SubCategory = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Winchester",
                    StockQuantity = 9,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 24,
                    Name = "Beretta 1301 Tactical",
                    Description = "Lightning-fast semi-automatic shotgun with advanced features.",
                    Price = 1399.99m,
                    Category = "Guns",
                    SubCategory = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Beretta",
                    StockQuantity = 4,
                    ImageUrl = "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== AMMO ==========
                new Product
                {
                    Id = 25,
                    Name = "9mm Luger Ammo - 50 Rounds",
                    Description = "Quality 9mm ammunition for target practice and self-defense. 115 grain FMJ.",
                    Price = 24.99m,
                    Category = "Ammo",
                    SubCategory = "Handgun Ammo",
                    Caliber = "9mm",
                    Manufacturer = "Federal",
                    StockQuantity = 100,
                    ImageUrl = "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 26,
                    Name = ".45 ACP Ammo - 50 Rounds",
                    Description = "Reliable .45 ACP ammunition for target shooting and self-defense.",
                    Price = 34.99m,
                    Category = "Ammo",
                    SubCategory = "Handgun Ammo",
                    Caliber = ".45 ACP",
                    Manufacturer = "Winchester",
                    StockQuantity = 80,
                    ImageUrl = "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 27,
                    Name = ".223 Remington Ammo - 20 Rounds",
                    Description = "High-quality .223 ammunition perfect for target shooting and training.",
                    Price = 19.99m,
                    Category = "Ammo",
                    SubCategory = "Rifle Ammo",
                    Caliber = ".223 Rem",
                    Manufacturer = "Winchester",
                    StockQuantity = 80,
                    ImageUrl = "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 28,
                    Name = "12 Gauge Buckshot - 25 Rounds",
                    Description = "Powerful 12 gauge buckshot ammunition for home defense and hunting.",
                    Price = 34.99m,
                    Category = "Ammo",
                    SubCategory = "Shotgun Ammo",
                    Caliber = "12 Gauge",
                    Manufacturer = "Remington",
                    StockQuantity = 60,
                    ImageUrl = "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 29,
                    Name = ".308 Winchester Ammo - 20 Rounds",
                    Description = "Premium .308 ammunition for hunting and long-range shooting.",
                    Price = 29.99m,
                    Category = "Ammo",
                    SubCategory = "Rifle Ammo",
                    Caliber = ".308 Win",
                    Manufacturer = "Hornady",
                    StockQuantity = 50,
                    ImageUrl = "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== ACCESSORIES ==========
                new Product
                {
                    Id = 30,
                    Name = "Glock 19 Magazine - 15 Rounds",
                    Description = "Factory OEM magazine for Glock 19 pistols. Reliable and durable.",
                    Price = 29.99m,
                    Category = "Accessories",
                    SubCategory = "Magazines",
                    Caliber = "9mm",
                    Manufacturer = "Glock",
                    StockQuantity = 25,
                    ImageUrl = "https://images.unsplash.com/photo-1544531585-9847b16c67cb?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 31,
                    Name = "AR-15 30 Round Magazine",
                    Description = "Standard capacity magazine for AR-15 platform rifles. PMAG design.",
                    Price = 14.99m,
                    Category = "Accessories",
                    SubCategory = "Magazines",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Magpul",
                    StockQuantity = 40,
                    ImageUrl = "https://images.unsplash.com/photo-1544531585-9847b16c67cb?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 32,
                    Name = "Universal Pistol Cleaning Kit",
                    Description = "Complete cleaning kit for all handgun calibers. Includes rods, brushes, and solvent.",
                    Price = 39.99m,
                    Category = "Accessories",
                    SubCategory = "Cleaning",
                    Caliber = "Multiple",
                    Manufacturer = "Hoppe's",
                    StockQuantity = 30,
                    ImageUrl = "https://images.unsplash.com/photo-1585776467777-4d2e1c2f1b1a?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 33,
                    Name = "Universal Tactical Sling",
                    Description = "Adjustable 2-point tactical sling for rifles and shotguns. Quick-adjust design.",
                    Price = 49.99m,
                    Category = "Accessories",
                    SubCategory = "Slings",
                    Caliber = "N/A",
                    Manufacturer = "Blue Force Gear",
                    StockQuantity = 20,
                    ImageUrl = "https://images.unsplash.com/photo-1585776467777-4d2e1c2f1b1a?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 34,
                    Name = "Electronic Hearing Protection",
                    Description = "Advanced electronic earmuffs that amplify ambient sounds while protecting from loud noises.",
                    Price = 89.99m,
                    Category = "Accessories",
                    SubCategory = "Hearing Protection",
                    Caliber = "N/A",
                    Manufacturer = "Walker's",
                    StockQuantity = 15,
                    ImageUrl = "https://images.unsplash.com/photo-1585776467777-4d2e1c2f1b1a?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 35,
                    Name = "Tactical Red Dot Sight",
                    Description = "Compact red dot sight with multiple reticle options for fast target acquisition.",
                    Price = 199.99m,
                    Category = "Accessories",
                    SubCategory = "Optics",
                    Caliber = "N/A",
                    Manufacturer = "Sig Sauer",
                    StockQuantity = 12,
                    ImageUrl = "https://images.unsplash.com/photo-1585776467777-4d2e1c2f1b1a?w=400&h=300&fit=crop",
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}