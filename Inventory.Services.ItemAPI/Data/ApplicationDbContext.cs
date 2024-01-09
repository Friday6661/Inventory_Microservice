using Inventory.Services.ItemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services.ItemAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Name = "LG",
                Quantity = 20,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 2,
                Name = "United Star",
                Quantity= 20,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }
    }
}
