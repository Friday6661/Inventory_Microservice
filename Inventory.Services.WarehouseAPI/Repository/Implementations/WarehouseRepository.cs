using Inventory.Services.WarehouseAPI.Data;
using Inventory.Services.WarehouseAPI.Models;
using Inventory.Services.WarehouseAPI.Models.Dto;
using Inventory.Services.WarehouseAPI.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using static Inventory.Services.WarehouseAPI.Models.Dto.Response;

namespace Inventory.Services.WarehouseAPI.Repository.Implementations
{
    public class WarehouseRepository : IWarehouse
    {
        private readonly ApplicationDbContext _context;

        public WarehouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponse> CreateWarehouseAsync(WarehouseDto warehouseDto)
        {
            if (warehouseDto is null) return new GeneralResponse(false, "Empty model");
            var warehouse = new Warehouse()
            {
                Name = warehouseDto.Name,
                Location = warehouseDto.Location,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Create Succes");

        }

        public async Task<GeneralResponse> DeleteWarehouseAsync(int id)
        {
            var warehouse = await _context.Warehouses.Where(w => w.Id == id).FirstOrDefaultAsync();
            if (warehouse is null) return new GeneralResponse(false, "Warehouse not found");
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Delete succes");

        }

        public async Task<ICollection<Warehouse>> GetWarehouseAsync()
        {
            var warehouses = await _context.Warehouses.ToListAsync();
            return warehouses;
        }

        public async Task<WarehouseResponse> GetWarehouseByIdAsync(int id)
        {
            var warehouse = await _context.Warehouses.Where(w => w.Id == id).FirstOrDefaultAsync();
            if (warehouse is null) return new WarehouseResponse(false, null!, "Warehouse not found");
            return new WarehouseResponse(true, warehouse, "Load succes");
        }

        public async Task<GeneralResponse> UpdateWarehouseAsync(int id, WarehouseDto warehouseDto)
        {
            var warehouse = await _context.Warehouses.Where(w => w.Id == id).FirstOrDefaultAsync();
            if (warehouse is null) return new GeneralResponse(false, "Warehouse not found");

            warehouse.Name = warehouseDto.Name;
            warehouse.Location = warehouseDto.Location;
            warehouse.UpdatedAt = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
                return new GeneralResponse(true, "Updated warehouse succes");
            }
            catch (DbUpdateException)
            {
                return new GeneralResponse(false, "Update failed");

            }
        }
    }
}
