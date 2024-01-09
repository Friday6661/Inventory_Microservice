using System.ComponentModel.DataAnnotations;
using Inventory.Services.ItemCategoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services.ItemCategoryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<ItemCategory> ItemCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory
            {
                Id = 1,
                Name = "Monitor",
                Description = "This is seed data",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory
            {
                Id = 2,
                Name = "Laptop",
                Description = "This is seed data",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }
    }
}
