﻿// <auto-generated />
using System;
using Inventory.Services.ItemCategoryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.Services.ItemCategoryAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240108082618_InitialItemCategory")]
    partial class InitialItemCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inventory.Services.ItemCategoryAPI.Models.ItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ItemCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 1, 8, 15, 26, 17, 913, DateTimeKind.Local).AddTicks(6042),
                            Description = "This is seed data",
                            Name = "Monitor",
                            UpdatedAt = new DateTime(2024, 1, 8, 15, 26, 17, 913, DateTimeKind.Local).AddTicks(6052)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 1, 8, 15, 26, 17, 913, DateTimeKind.Local).AddTicks(6085),
                            Description = "This is seed data",
                            Name = "Laptop",
                            UpdatedAt = new DateTime(2024, 1, 8, 15, 26, 17, 913, DateTimeKind.Local).AddTicks(6085)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
