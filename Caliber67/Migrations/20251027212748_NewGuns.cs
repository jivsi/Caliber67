using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Caliber67.Migrations
{
    /// <inheritdoc />
    public partial class NewGuns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2069), "Compact 9mm pistol, perfect for concealed carry and home defense. Features a modular design and reliable performance." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Caliber", "Category", "CreatedDate", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "StockQuantity" },
                values: new object[] { "9mm", "Handgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2072), "Modular striker-fired pistol with exceptional accuracy and customizable grip modules.", "/images/sigp320.jpg", "Sig Sauer", "Sig Sauer P320 XCompact", 649.99m, 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Caliber", "Category", "CreatedDate", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "StockQuantity" },
                values: new object[] { "9mm", "Handgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2074), "Ultra-compact pistol with 13+1 capacity, perfect for everyday concealed carry.", "/images/mpshield.jpg", "Smith & Wesson", "Smith & Wesson M&P Shield Plus", 499.99m, 20 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Caliber", "Category", "CreatedDate", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 4, ".45 ACP", "Handgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2076), "Classic 1911 design with modern features, offering exceptional accuracy and smooth operation.", "/images/1911ronin.jpg", "Springfield Armory", "Springfield 1911 Ronin", 899.99m, 8 },
                    { 5, "9mm", "Handgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2077), "Ergonomic striker-fired pistol with excellent trigger and superior ergonomics.", "/images/czp10c.jpg", "CZ", "CZ P-10 C", 499.99m, 18 },
                    { 6, "9mm", "Handgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2079), "Micro-compact pistol with 15+1 capacity, perfect for everyday concealed carry.", "/images/hellcat.jpg", "Springfield Armory", "Springfield Hellcat Pro", 599.99m, 22 },
                    { 7, "9mm", "Handgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2081), "Duty-grade pistol with suppressor-height sights and threaded barrel.", "/images/fn509.jpg", "FN Herstal", "FN 509 Tactical", 899.99m, 6 },
                    { 8, "9mm", "Handgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2082), "Performance Duty Pistol with superior ergonomics and lightning-fast trigger.", "/images/waltherpdp.jpg", "Walther", "Walther PDP Compact", 649.99m, 10 },
                    { 9, "5.56 NATO", "Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2084), "Reliable AR-15 platform rifle for sport shooting, home defense, and tactical applications.", "/images/mp15.jpg", "Smith & Wesson", "Smith & Wesson M&P15 Sport II", 799.99m, 10 },
                    { 10, ".22 LR", "Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2086), "Classic .22 LR rifle perfect for training, plinking, and small game hunting.", "/images/ruger1022.jpg", "Ruger", "Ruger 10/22 Carbine", 329.99m, 25 },
                    { 11, "5.56 NATO", "Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2087), "Premium AR-15 with advanced features for serious shooters and professionals.", "/images/ddm4v7.jpg", "Daniel Defense", "Daniel Defense DDM4 V7", 1799.99m, 4 },
                    { 12, "5.56 NATO", "Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2089), "High-performance AR-15 with enhanced features for competitive shooting.", "/images/saintvictor.jpg", "Springfield Armory", "Springfield Saint Victor", 1099.99m, 7 },
                    { 13, "5.56 NATO", "Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2091), "Reliable and affordable AR-15 platform rifle made in the USA.", "/images/rugerar556.jpg", "Ruger", "Ruger AR-556", 799.99m, 15 },
                    { 14, "5.56 NATO", "Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2092), "Quality-built AR-15 with premium components and excellent accuracy.", "/images/aeroac15.jpg", "Aero Precision", "Aero Precision AC-15", 899.99m, 8 },
                    { 15, ".308 Winchester", "Sniper Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2094), "Bolt-action precision rifle with heavy barrel for long-range accuracy.", "/images/remington700.jpg", "Remington", "Remington 700 SPS Tactical", 799.99m, 6 },
                    { 16, "6.5 Creedmoor", "Sniper Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2095), "Modular bolt-action rifle designed for long-range precision shooting.", "/images/rugerprecision.jpg", "Ruger", "Ruger Precision Rifle", 1399.99m, 3 },
                    { 17, ".308 Winchester", "Sniper Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2097), "Hybrid Match Rifle with exceptional out-of-the-box accuracy.", "/images/bergara.jpg", "Bergara", "Bergara B-14 HMR", 999.99m, 5 },
                    { 18, "6.5 Creedmoor", "Sniper Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2099), "Modern tactical chassis rifle with outstanding accuracy and modularity.", "/images/tikkat3x.jpg", "Tikka", "Tikka T3x TAC A1", 1999.99m, 2 },
                    { 19, ".308 Winchester", "Sniper Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2100), "Budget-friendly precision rifle with excellent accuracy for the price.", "/images/savage110.jpg", "Savage", "Savage 110 Precision", 1199.99m, 7 },
                    { 20, "12 Gauge", "Shotgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2102), "Dependable pump-action shotgun for hunting, home security, and sport shooting.", "/images/remington870.jpg", "Remington", "Remington 870 Express", 449.99m, 12 },
                    { 21, "12 Gauge", "Shotgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2104), "Versatile pump-action shotgun designed specifically for home defense applications.", "/images/mossberg500.jpg", "Mossberg", "Mossberg 500 Security", 419.99m, 15 },
                    { 22, "12 Gauge", "Shotgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2105), "Semi-automatic tactical shotgun used by military and law enforcement worldwide.", "/images/benellim4.jpg", "Benelli", "Benelli M4", 1899.99m, 3 },
                    { 23, "12 Gauge", "Shotgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2107), "Fast-action pump shotgun with smooth operation for home defense.", "/images/winchestersxp.jpg", "Winchester", "Winchester SXP Defender", 379.99m, 9 },
                    { 24, "12 Gauge", "Shotgun", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2109), "Lightning-fast semi-automatic shotgun with advanced features.", "/images/beretta1301.jpg", "Beretta", "Beretta 1301 Tactical", 1399.99m, 4 },
                    { 25, "9mm", "PCC", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2110), "Compact pistol caliber carbine with minimal recoil and high maneuverability.", "/images/mpxcopperhead.jpg", "Sig Sauer", "Sig Sauer MPX Copperhead", 1799.99m, 5 },
                    { 26, "9mm", "PCC", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2112), "Takedown carbine that accepts Ruger and Glock magazines.", "/images/rugerpc.jpg", "Ruger", "Ruger PC Carbine", 699.99m, 12 },
                    { 27, "9mm", "PCC", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2114), "Modern pistol caliber carbine with modular design and low recoil.", "/images/czscorpion.jpg", "CZ", "CZ Scorpion EVO 3 S1", 899.99m, 8 },
                    { 28, ".30-06 Springfield", "Hunting Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2115), "Lightweight hunting rifle with smooth bolt operation and excellent accuracy.", "/images/browningxbolt.jpg", "Browning", "Browning X-Bolt Hunter", 1099.99m, 6 },
                    { 29, ".300 Win Mag", "Hunting Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2117), "Sub-MOA guaranteed hunting rifle with Weatherby accuracy.", "/images/weatherby.jpg", "Weatherby", "Weatherby Vanguard", 799.99m, 4 },
                    { 30, ".22 LR", "Hunting Rifle", new DateTime(2025, 10, 27, 21, 27, 47, 554, DateTimeKind.Utc).AddTicks(2119), "Beautiful lever-action rifle with brass receiver and American walnut stock.", "/images/goldenboy.jpg", "Henry", "Henry Golden Boy", 899.99m, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2025, 10, 27, 20, 56, 34, 465, DateTimeKind.Utc).AddTicks(222), "Compact 9mm pistol, perfect for concealed carry and home defense." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Caliber", "Category", "CreatedDate", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "StockQuantity" },
                values: new object[] { "5.56 NATO", "Rifle", new DateTime(2025, 10, 27, 20, 56, 34, 465, DateTimeKind.Utc).AddTicks(228), "Reliable AR-15 platform rifle for sport shooting and home defense.", "/images/mp15.jpg", "Smith & Wesson", "Smith & Wesson M&P15 Sport II", 799.99m, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Caliber", "Category", "CreatedDate", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "StockQuantity" },
                values: new object[] { "12 Gauge", "Shotgun", new DateTime(2025, 10, 27, 20, 56, 34, 465, DateTimeKind.Utc).AddTicks(229), "Dependable pump-action shotgun for hunting and home security.", "/images/remington870.jpg", "Remington", "Remington 870 Express", 449.99m, 12 });
        }
    }
}
