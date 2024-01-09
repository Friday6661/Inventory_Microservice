using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Services.ItemAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixNameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCategories",
                table: "ItemCategories");

            migrationBuilder.RenameTable(
                name: "ItemCategories",
                newName: "Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 57, 37, 479, DateTimeKind.Local).AddTicks(581), new DateTime(2024, 1, 8, 20, 57, 37, 479, DateTimeKind.Local).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 57, 37, 479, DateTimeKind.Local).AddTicks(622), new DateTime(2024, 1, 8, 20, 57, 37, 479, DateTimeKind.Local).AddTicks(623) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "ItemCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCategories",
                table: "ItemCategories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 53, 40, 239, DateTimeKind.Local).AddTicks(3207), new DateTime(2024, 1, 8, 20, 53, 40, 239, DateTimeKind.Local).AddTicks(3217) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 53, 40, 239, DateTimeKind.Local).AddTicks(3253), new DateTime(2024, 1, 8, 20, 53, 40, 239, DateTimeKind.Local).AddTicks(3254) });
        }
    }
}
