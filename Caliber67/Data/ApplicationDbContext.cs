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

            // ========== SEED DATA - 30 FIREARMS ==========
            builder.Entity<Product>().HasData(
                // ========== HANDGUNS ==========
                new Product
                {
                    Id = 1,
                    Name = "Glock 19 Gen 5",
                    Description = "Compact 9mm pistol, perfect for concealed carry and home defense. Features a modular design and reliable performance.",
                    Price = 549.99m,
                    Category = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Glock",
                    StockQuantity = 15,
                    ImageUrl = "/images/glock19.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 2,
                    Name = "Sig Sauer P320 XCompact",
                    Description = "Modular striker-fired pistol with exceptional accuracy and customizable grip modules.",
                    Price = 649.99m,
                    Category = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Sig Sauer",
                    StockQuantity = 12,
                    ImageUrl = "/images/sigp320.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 3,
                    Name = "Smith & Wesson M&P Shield Plus",
                    Description = "Ultra-compact pistol with 13+1 capacity, perfect for everyday concealed carry.",
                    Price = 499.99m,
                    Category = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Smith & Wesson",
                    StockQuantity = 20,
                    ImageUrl = "/images/mpshield.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 4,
                    Name = "Springfield 1911 Ronin",
                    Description = "Classic 1911 design with modern features, offering exceptional accuracy and smooth operation.",
                    Price = 899.99m,
                    Category = "Handgun",
                    Caliber = ".45 ACP",
                    Manufacturer = "Springfield Armory",
                    StockQuantity = 8,
                    ImageUrl = "/images/1911ronin.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 5,
                    Name = "CZ P-10 C",
                    Description = "Ergonomic striker-fired pistol with excellent trigger and superior ergonomics.",
                    Price = 499.99m,
                    Category = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "CZ",
                    StockQuantity = 18,
                    ImageUrl = "/images/czp10c.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 6,
                    Name = "Springfield Hellcat Pro",
                    Description = "Micro-compact pistol with 15+1 capacity, perfect for everyday concealed carry.",
                    Price = 599.99m,
                    Category = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Springfield Armory",
                    StockQuantity = 22,
                    ImageUrl = "/images/hellcat.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 7,
                    Name = "FN 509 Tactical",
                    Description = "Duty-grade pistol with suppressor-height sights and threaded barrel.",
                    Price = 899.99m,
                    Category = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "FN Herstal",
                    StockQuantity = 6,
                    ImageUrl = "/images/fn509.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 8,
                    Name = "Walther PDP Compact",
                    Description = "Performance Duty Pistol with superior ergonomics and lightning-fast trigger.",
                    Price = 649.99m,
                    Category = "Handgun",
                    Caliber = "9mm",
                    Manufacturer = "Walther",
                    StockQuantity = 10,
                    ImageUrl = "/images/waltherpdp.jpg",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== RIFLES ==========
                new Product
                {
                    Id = 9,
                    Name = "Smith & Wesson M&P15 Sport II",
                    Description = "Reliable AR-15 platform rifle for sport shooting, home defense, and tactical applications.",
                    Price = 799.99m,
                    Category = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Smith & Wesson",
                    StockQuantity = 10,
                    ImageUrl = "/images/mp15.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 10,
                    Name = "Ruger 10/22 Carbine",
                    Description = "Classic .22 LR rifle perfect for training, plinking, and small game hunting.",
                    Price = 329.99m,
                    Category = "Rifle",
                    Caliber = ".22 LR",
                    Manufacturer = "Ruger",
                    StockQuantity = 25,
                    ImageUrl = "/images/ruger1022.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 11,
                    Name = "Daniel Defense DDM4 V7",
                    Description = "Premium AR-15 with advanced features for serious shooters and professionals.",
                    Price = 1799.99m,
                    Category = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Daniel Defense",
                    StockQuantity = 4,
                    ImageUrl = "/images/ddm4v7.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 12,
                    Name = "Springfield Saint Victor",
                    Description = "High-performance AR-15 with enhanced features for competitive shooting.",
                    Price = 1099.99m,
                    Category = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Springfield Armory",
                    StockQuantity = 7,
                    ImageUrl = "/images/saintvictor.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 13,
                    Name = "Ruger AR-556",
                    Description = "Reliable and affordable AR-15 platform rifle made in the USA.",
                    Price = 799.99m,
                    Category = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Ruger",
                    StockQuantity = 15,
                    ImageUrl = "/images/rugerar556.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 14,
                    Name = "Aero Precision AC-15",
                    Description = "Quality-built AR-15 with premium components and excellent accuracy.",
                    Price = 899.99m,
                    Category = "Rifle",
                    Caliber = "5.56 NATO",
                    Manufacturer = "Aero Precision",
                    StockQuantity = 8,
                    ImageUrl = "/images/aeroac15.jpg",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== SNIPER RIFLES ==========
                new Product
                {
                    Id = 15,
                    Name = "Remington 700 SPS Tactical",
                    Description = "Bolt-action precision rifle with heavy barrel for long-range accuracy.",
                    Price = 799.99m,
                    Category = "Sniper Rifle",
                    Caliber = ".308 Winchester",
                    Manufacturer = "Remington",
                    StockQuantity = 6,
                    ImageUrl = "/images/remington700.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 16,
                    Name = "Ruger Precision Rifle",
                    Description = "Modular bolt-action rifle designed for long-range precision shooting.",
                    Price = 1399.99m,
                    Category = "Sniper Rifle",
                    Caliber = "6.5 Creedmoor",
                    Manufacturer = "Ruger",
                    StockQuantity = 3,
                    ImageUrl = "/images/rugerprecision.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 17,
                    Name = "Bergara B-14 HMR",
                    Description = "Hybrid Match Rifle with exceptional out-of-the-box accuracy.",
                    Price = 999.99m,
                    Category = "Sniper Rifle",
                    Caliber = ".308 Winchester",
                    Manufacturer = "Bergara",
                    StockQuantity = 5,
                    ImageUrl = "/images/bergara.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 18,
                    Name = "Tikka T3x TAC A1",
                    Description = "Modern tactical chassis rifle with outstanding accuracy and modularity.",
                    Price = 1999.99m,
                    Category = "Sniper Rifle",
                    Caliber = "6.5 Creedmoor",
                    Manufacturer = "Tikka",
                    StockQuantity = 2,
                    ImageUrl = "/images/tikkat3x.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 19,
                    Name = "Savage 110 Precision",
                    Description = "Budget-friendly precision rifle with excellent accuracy for the price.",
                    Price = 1199.99m,
                    Category = "Sniper Rifle",
                    Caliber = ".308 Winchester",
                    Manufacturer = "Savage",
                    StockQuantity = 7,
                    ImageUrl = "/images/savage110.jpg",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== SHOTGUNS ==========
                new Product
                {
                    Id = 20,
                    Name = "Remington 870 Express",
                    Description = "Dependable pump-action shotgun for hunting, home security, and sport shooting.",
                    Price = 449.99m,
                    Category = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Remington",
                    StockQuantity = 12,
                    ImageUrl = "/images/remington870.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 21,
                    Name = "Mossberg 500 Security",
                    Description = "Versatile pump-action shotgun designed specifically for home defense applications.",
                    Price = 419.99m,
                    Category = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Mossberg",
                    StockQuantity = 15,
                    ImageUrl = "/images/mossberg500.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 22,
                    Name = "Benelli M4",
                    Description = "Semi-automatic tactical shotgun used by military and law enforcement worldwide.",
                    Price = 1899.99m,
                    Category = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Benelli",
                    StockQuantity = 3,
                    ImageUrl = "/images/benellim4.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 23,
                    Name = "Winchester SXP Defender",
                    Description = "Fast-action pump shotgun with smooth operation for home defense.",
                    Price = 379.99m,
                    Category = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Winchester",
                    StockQuantity = 9,
                    ImageUrl = "/images/winchestersxp.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 24,
                    Name = "Beretta 1301 Tactical",
                    Description = "Lightning-fast semi-automatic shotgun with advanced features.",
                    Price = 1399.99m,
                    Category = "Shotgun",
                    Caliber = "12 Gauge",
                    Manufacturer = "Beretta",
                    StockQuantity = 4,
                    ImageUrl = "/images/beretta1301.jpg",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== PCC (Pistol Caliber Carbines) ==========
                new Product
                {
                    Id = 25,
                    Name = "Sig Sauer MPX Copperhead",
                    Description = "Compact pistol caliber carbine with minimal recoil and high maneuverability.",
                    Price = 1799.99m,
                    Category = "PCC",
                    Caliber = "9mm",
                    Manufacturer = "Sig Sauer",
                    StockQuantity = 5,
                    ImageUrl = "/images/mpxcopperhead.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 26,
                    Name = "Ruger PC Carbine",
                    Description = "Takedown carbine that accepts Ruger and Glock magazines.",
                    Price = 699.99m,
                    Category = "PCC",
                    Caliber = "9mm",
                    Manufacturer = "Ruger",
                    StockQuantity = 12,
                    ImageUrl = "/images/rugerpc.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 27,
                    Name = "CZ Scorpion EVO 3 S1",
                    Description = "Modern pistol caliber carbine with modular design and low recoil.",
                    Price = 899.99m,
                    Category = "PCC",
                    Caliber = "9mm",
                    Manufacturer = "CZ",
                    StockQuantity = 8,
                    ImageUrl = "/images/czscorpion.jpg",
                    CreatedDate = DateTime.UtcNow
                },

                // ========== HUNTING RIFLES ==========
                new Product
                {
                    Id = 28,
                    Name = "Browning X-Bolt Hunter",
                    Description = "Lightweight hunting rifle with smooth bolt operation and excellent accuracy.",
                    Price = 1099.99m,
                    Category = "Hunting Rifle",
                    Caliber = ".30-06 Springfield",
                    Manufacturer = "Browning",
                    StockQuantity = 6,
                    ImageUrl = "/images/browningxbolt.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 29,
                    Name = "Weatherby Vanguard",
                    Description = "Sub-MOA guaranteed hunting rifle with Weatherby accuracy.",
                    Price = 799.99m,
                    Category = "Hunting Rifle",
                    Caliber = ".300 Win Mag",
                    Manufacturer = "Weatherby",
                    StockQuantity = 4,
                    ImageUrl = "/images/weatherby.jpg",
                    CreatedDate = DateTime.UtcNow
                },
                new Product
                {
                    Id = 30,
                    Name = "Henry Golden Boy",
                    Description = "Beautiful lever-action rifle with brass receiver and American walnut stock.",
                    Price = 899.99m,
                    Category = "Hunting Rifle",
                    Caliber = ".22 LR",
                    Manufacturer = "Henry",
                    StockQuantity = 7,
                    ImageUrl = "/images/goldenboy.jpg",
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}