﻿// <auto-generated />
using System;
using Inventory.Services.ItemAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.Services.ItemAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240108135738_FixNameTables")]
    partial class FixNameTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inventory.Services.ItemAPI.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 1, 8, 20, 57, 37, 479, DateTimeKind.Local).AddTicks(581),
                            Name = "LG",
                            Quantity = 20,
                            UpdatedAt = new DateTime(2024, 1, 8, 20, 57, 37, 479, DateTimeKind.Local).AddTicks(590)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 1, 8, 20, 57, 37, 479, DateTimeKind.Local).AddTicks(622),
                            Name = "United Star",
                            Quantity = 20,
                            UpdatedAt = new DateTime(2024, 1, 8, 20, 57, 37, 479, DateTimeKind.Local).AddTicks(623)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
