using Inventory.Services.ItemAPI.Data;
using Inventory.Services.ItemAPI.Models;
using Inventory.Services.ItemAPI.Models.Dto;
using Inventory.Services.ItemAPI.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using static Inventory.Services.ItemAPI.Models.Dto.Response;

namespace Inventory.Services.ItemAPI.Repository.Implementations
{
    public class ItemRepositories : IItem
    {
        private readonly ApplicationDbContext _context;
        public ItemRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponse> CreateItemAsync(ItemDto itemDto)
        {
            if (itemDto is null) return new GeneralResponse(false, "Empty model");
            var item = new Item()
            {
                Name = itemDto.Name,
                Quantity = itemDto.Quantity,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return new GeneralResponse(true, "Create succes");
        }

        public async Task<GeneralResponse> DeleteItemAsync(int id)
        {
            var item = await _context.Items.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (item is null) return new GeneralResponse(false, "Item not found");

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Delete succes");
        }

        public async Task<ICollection<Item>> GetItemAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<ItemResponse> GetItemByIdAsync(int id)
        {
            var item = await _context.Items.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (item is null) return new ItemResponse(false, null!, "Item not found");
            return new ItemResponse(true, item, "Load succes");
        }

        public async Task<GeneralResponse> UpdateItemAsync(int id, ItemDto itemDto)
        {
            var item = await _context.Items.Where(ic => ic.Id == id).FirstOrDefaultAsync();
            if (item is null) return new GeneralResponse(false, "Item category not found");

            item.Name = itemDto.Name;
            item.Quantity = itemDto.Quantity;
            item.UpdatedAt = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
                return new GeneralResponse(true, "Updated item succes");
            }
            catch (DbUpdateException)
            {
                return new GeneralResponse(false, "Update failed");
            }
        }
    }
}
