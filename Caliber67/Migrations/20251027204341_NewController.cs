using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caliber67.Migrations
{
    /// <inheritdoc />
    public partial class NewController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 43, 40, 649, DateTimeKind.Utc).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 43, 40, 649, DateTimeKind.Utc).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 43, 40, 649, DateTimeKind.Utc).AddTicks(2900));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 32, 39, 295, DateTimeKind.Utc).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 32, 39, 295, DateTimeKind.Utc).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 32, 39, 295, DateTimeKind.Utc).AddTicks(5145));
        }
    }
}
