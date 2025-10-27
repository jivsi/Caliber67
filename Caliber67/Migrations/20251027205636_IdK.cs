using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caliber67.Migrations
{
    /// <inheritdoc />
    public partial class IdK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 56, 34, 465, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 56, 34, 465, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 10, 27, 20, 56, 34, 465, DateTimeKind.Utc).AddTicks(229));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
