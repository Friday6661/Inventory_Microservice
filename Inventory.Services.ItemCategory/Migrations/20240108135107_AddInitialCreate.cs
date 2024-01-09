using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Services.ItemCategoryAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 51, 6, 585, DateTimeKind.Local).AddTicks(9747), new DateTime(2024, 1, 8, 20, 51, 6, 585, DateTimeKind.Local).AddTicks(9756) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 51, 6, 585, DateTimeKind.Local).AddTicks(9792), new DateTime(2024, 1, 8, 20, 51, 6, 585, DateTimeKind.Local).AddTicks(9793) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 15, 26, 17, 913, DateTimeKind.Local).AddTicks(6042), new DateTime(2024, 1, 8, 15, 26, 17, 913, DateTimeKind.Local).AddTicks(6052) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 15, 26, 17, 913, DateTimeKind.Local).AddTicks(6085), new DateTime(2024, 1, 8, 15, 26, 17, 913, DateTimeKind.Local).AddTicks(6085) });
        }
    }
}
