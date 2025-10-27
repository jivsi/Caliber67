using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Caliber67.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsOfLegalAge = table.Column<bool>(type: "INTEGER", nullable: true),
                    AgeVerifiedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SubCategory = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Caliber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    OrderNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ShippingFirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ShippingLastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ShippingAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ShippingCity = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ShippingState = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ShippingZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ShippingPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingEmail = table.Column<string>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeliveredDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Caliber", "Category", "CreatedDate", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "StockQuantity", "SubCategory" },
                values: new object[,]
                {
                    { 1, "9mm", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1369), "Compact 9mm pistol, perfect for concealed carry and home defense. Features a modular design and reliable performance.", "https://images.unsplash.com/photo-1595590424281-b0aefc285822?w=400&h=300&fit=crop", "Glock", "Glock 19 Gen 5", 549.99m, 15, "Handgun" },
                    { 2, "9mm", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1371), "Modular striker-fired pistol with exceptional accuracy and customizable grip modules.", "https://images.unsplash.com/photo-1595593179760-23fef6a0d95a?w=400&h=300&fit=crop", "Sig Sauer", "Sig Sauer P320 XCompact", 649.99m, 12, "Handgun" },
                    { 3, "9mm", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1373), "Ultra-compact pistol with 13+1 capacity, perfect for everyday concealed carry.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Smith & Wesson", "Smith & Wesson M&P Shield Plus", 499.99m, 20, "Handgun" },
                    { 4, ".45 ACP", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1375), "Classic 1911 design with modern features, offering exceptional accuracy and smooth operation.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Springfield Armory", "Springfield 1911 Ronin", 899.99m, 8, "Handgun" },
                    { 5, "9mm", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1377), "Ergonomic striker-fired pistol with excellent trigger and superior ergonomics.", "https://images.unsplash.com/photo-1595590424281-b0aefc285822?w=400&h=300&fit=crop", "CZ", "CZ P-10 C", 499.99m, 18, "Handgun" },
                    { 6, "9mm", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1379), "Micro-compact pistol with 15+1 capacity, perfect for everyday concealed carry.", "https://images.unsplash.com/photo-1595593179760-23fef6a0d95a?w=400&h=300&fit=crop", "Springfield Armory", "Springfield Hellcat Pro", 599.99m, 22, "Handgun" },
                    { 7, "9mm", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1381), "Duty-grade pistol with suppressor-height sights and threaded barrel.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "FN Herstal", "FN 509 Tactical", 899.99m, 6, "Handgun" },
                    { 8, "9mm", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1382), "Performance Duty Pistol with superior ergonomics and lightning-fast trigger.", "https://images.unsplash.com/photo-1595590424281-b0aefc285822?w=400&h=300&fit=crop", "Walther", "Walther PDP Compact", 649.99m, 10, "Handgun" },
                    { 9, "5.56 NATO", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1384), "Reliable AR-15 platform rifle for sport shooting, home defense, and tactical applications.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Smith & Wesson", "Smith & Wesson M&P15 Sport II", 799.99m, 10, "Rifle" },
                    { 10, ".22 LR", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1386), "Classic .22 LR rifle perfect for training, plinking, and small game hunting.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Ruger", "Ruger 10/22 Carbine", 329.99m, 25, "Rifle" },
                    { 11, "5.56 NATO", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1387), "Premium AR-15 with advanced features for serious shooters and professionals.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Daniel Defense", "Daniel Defense DDM4 V7", 1799.99m, 4, "Rifle" },
                    { 12, "5.56 NATO", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1389), "High-performance AR-15 with enhanced features for competitive shooting.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Springfield Armory", "Springfield Saint Victor", 1099.99m, 7, "Rifle" },
                    { 13, "5.56 NATO", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1391), "Reliable and affordable AR-15 platform rifle made in the USA.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Ruger", "Ruger AR-556", 799.99m, 15, "Rifle" },
                    { 14, "5.56 NATO", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1393), "Quality-built AR-15 with premium components and excellent accuracy.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Aero Precision", "Aero Precision AC-15", 899.99m, 8, "Rifle" },
                    { 15, ".308 Winchester", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1394), "Bolt-action precision rifle with heavy barrel for long-range accuracy.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Remington", "Remington 700 SPS Tactical", 799.99m, 6, "Sniper Rifle" },
                    { 16, "6.5 Creedmoor", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1472), "Modular bolt-action rifle designed for long-range precision shooting.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Ruger", "Ruger Precision Rifle", 1399.99m, 3, "Sniper Rifle" },
                    { 17, ".308 Winchester", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1474), "Hybrid Match Rifle with exceptional out-of-the-box accuracy.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Bergara", "Bergara B-14 HMR", 999.99m, 5, "Sniper Rifle" },
                    { 18, "6.5 Creedmoor", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1476), "Modern tactical chassis rifle with outstanding accuracy and modularity.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Tikka", "Tikka T3x TAC A1", 1999.99m, 2, "Sniper Rifle" },
                    { 19, ".308 Winchester", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1477), "Budget-friendly precision rifle with excellent accuracy for the price.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Savage", "Savage 110 Precision", 1199.99m, 7, "Sniper Rifle" },
                    { 20, "12 Gauge", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1479), "Dependable pump-action shotgun for hunting, home security, and sport shooting.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Remington", "Remington 870 Express", 449.99m, 12, "Shotgun" },
                    { 21, "12 Gauge", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1481), "Versatile pump-action shotgun designed specifically for home defense applications.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Mossberg", "Mossberg 500 Security", 419.99m, 15, "Shotgun" },
                    { 22, "12 Gauge", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1483), "Semi-automatic tactical shotgun used by military and law enforcement worldwide.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Benelli", "Benelli M4", 1899.99m, 3, "Shotgun" },
                    { 23, "12 Gauge", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1484), "Fast-action pump shotgun with smooth operation for home defense.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Winchester", "Winchester SXP Defender", 379.99m, 9, "Shotgun" },
                    { 24, "12 Gauge", "Guns", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1486), "Lightning-fast semi-automatic shotgun with advanced features.", "https://images.unsplash.com/photo-1594282482181-7c26e64bc912?w=400&h=300&fit=crop", "Beretta", "Beretta 1301 Tactical", 1399.99m, 4, "Shotgun" },
                    { 25, "9mm", "Ammo", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1488), "Quality 9mm ammunition for target practice and self-defense. 115 grain FMJ.", "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop", "Federal", "9mm Luger Ammo - 50 Rounds", 24.99m, 100, "Handgun Ammo" },
                    { 26, ".45 ACP", "Ammo", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1489), "Reliable .45 ACP ammunition for target shooting and self-defense.", "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop", "Winchester", ".45 ACP Ammo - 50 Rounds", 34.99m, 80, "Handgun Ammo" },
                    { 27, ".223 Rem", "Ammo", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1491), "High-quality .223 ammunition perfect for target shooting and training.", "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop", "Winchester", ".223 Remington Ammo - 20 Rounds", 19.99m, 80, "Rifle Ammo" },
                    { 28, "12 Gauge", "Ammo", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1493), "Powerful 12 gauge buckshot ammunition for home defense and hunting.", "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop", "Remington", "12 Gauge Buckshot - 25 Rounds", 34.99m, 60, "Shotgun Ammo" },
                    { 29, ".308 Win", "Ammo", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1495), "Premium .308 ammunition for hunting and long-range shooting.", "https://images.unsplash.com/photo-1577401232313-575cd2f32643?w=400&h=300&fit=crop", "Hornady", ".308 Winchester Ammo - 20 Rounds", 29.99m, 50, "Rifle Ammo" },
                    { 30, "9mm", "Accessories", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1496), "Factory OEM magazine for Glock 19 pistols. Reliable and durable.", "https://images.unsplash.com/photo-1544531585-9847b16c67cb?w=400&h=300&fit=crop", "Glock", "Glock 19 Magazine - 15 Rounds", 29.99m, 25, "Magazines" },
                    { 31, "5.56 NATO", "Accessories", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1498), "Standard capacity magazine for AR-15 platform rifles. PMAG design.", "https://images.unsplash.com/photo-1544531585-9847b16c67cb?w=400&h=300&fit=crop", "Magpul", "AR-15 30 Round Magazine", 14.99m, 40, "Magazines" },
                    { 32, "Multiple", "Accessories", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1500), "Complete cleaning kit for all handgun calibers. Includes rods, brushes, and solvent.", "https://images.unsplash.com/photo-1585776467777-4d2e1c2f1b1a?w=400&h=300&fit=crop", "Hoppe's", "Universal Pistol Cleaning Kit", 39.99m, 30, "Cleaning" },
                    { 33, "N/A", "Accessories", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1502), "Adjustable 2-point tactical sling for rifles and shotguns. Quick-adjust design.", "https://images.unsplash.com/photo-1585776467777-4d2e1c2f1b1a?w=400&h=300&fit=crop", "Blue Force Gear", "Universal Tactical Sling", 49.99m, 20, "Slings" },
                    { 34, "N/A", "Accessories", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1503), "Advanced electronic earmuffs that amplify ambient sounds while protecting from loud noises.", "https://images.unsplash.com/photo-1585776467777-4d2e1c2f1b1a?w=400&h=300&fit=crop", "Walker's", "Electronic Hearing Protection", 89.99m, 15, "Hearing Protection" },
                    { 35, "N/A", "Accessories", new DateTime(2025, 10, 27, 22, 33, 0, 728, DateTimeKind.Utc).AddTicks(1505), "Compact red dot sight with multiple reticle options for fast target acquisition.", "https://images.unsplash.com/photo-1585776467777-4d2e1c2f1b1a?w=400&h=300&fit=crop", "Sig Sauer", "Tactical Red Dot Sight", 199.99m, 12, "Optics" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
