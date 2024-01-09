using Inventory.Services.WarehouseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services.WarehouseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Warehouse>().HasData(new Warehouse
            {
                Id = 1,
                Name = "First",
                Location = "Warehouse 1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            modelBuilder.Entity<Warehouse>().HasData(new Warehouse
            {
                Id = 2,
                Name = "Second",
                Location = "Warehouse 2",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }
    }
}
