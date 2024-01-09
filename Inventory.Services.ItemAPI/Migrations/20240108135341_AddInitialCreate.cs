using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inventory.Services.ItemAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "CreatedAt", "Name", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 8, 20, 53, 40, 239, DateTimeKind.Local).AddTicks(3207), "LG", 20, new DateTime(2024, 1, 8, 20, 53, 40, 239, DateTimeKind.Local).AddTicks(3217) },
                    { 2, new DateTime(2024, 1, 8, 20, 53, 40, 239, DateTimeKind.Local).AddTicks(3253), "United Star", 20, new DateTime(2024, 1, 8, 20, 53, 40, 239, DateTimeKind.Local).AddTicks(3254) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCategories");
        }
    }
}
