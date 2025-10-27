using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caliber67.Migrations
{
    /// <inheritdoc />
    public partial class NewScaffolds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 15, 33, 197, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 15, 33, 197, DateTimeKind.Utc).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 15, 33, 197, DateTimeKind.Utc).AddTicks(9407));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 9, 17, 925, DateTimeKind.Utc).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 9, 17, 925, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 9, 17, 925, DateTimeKind.Utc).AddTicks(123));
        }
    }
}
