using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caliber67.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserFieldsOptionala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 29, 33, 86, DateTimeKind.Utc).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 29, 33, 86, DateTimeKind.Utc).AddTicks(8337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 29, 33, 86, DateTimeKind.Utc).AddTicks(8339));
        }
    }
}
