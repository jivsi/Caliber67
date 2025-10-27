using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caliber67.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentitySupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 26, 47, 174, DateTimeKind.Utc).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 26, 47, 174, DateTimeKind.Utc).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 26, 47, 174, DateTimeKind.Utc).AddTicks(9493));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
