using AutoMapper;
using Azure;
using Inventory.Services.ItemCategoryAPI.Data;
using Inventory.Services.ItemCategoryAPI.Models;
using Inventory.Services.ItemCategoryAPI.Models.Dto;
using Inventory.Services.ItemCategoryAPI.Repository.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static Inventory.Services.ItemCategoryAPI.Models.Dto.Response;

namespace Inventory.Services.ItemCategoryAPI.Repository.Implementations
{
    public class ItemCategoryRepositories : IItemCategory
    {
        private readonly ApplicationDbContext _context;

        public ItemCategoryRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponse> CreateItemCategoryAsync(ItemCategoryDto itemCategoryDto)
        {
            if (itemCategoryDto is null) return new GeneralResponse(false, "Model is empty");
            var itemCategory = new ItemCategory()
            {
                Name = itemCategoryDto.Name,
                Description = itemCategoryDto.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            _context.ItemCategories.Add(itemCategory);
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Create succes");
        }

        public async Task<GeneralResponse> DeleteItemCategoryAsync(int id)
        {
            var itemCategory = _context.ItemCategories.Where(ic => ic.Id == id).FirstOrDefault();
            if (itemCategory is null) return new GeneralResponse(false, "Item category not found");

            _context.ItemCategories.Remove(itemCategory);
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Delete Success");
        }

        public async Task<ICollection<ItemCategory>> GetItemCategoriesAsync()
        {
            var itemCategories = await _context.ItemCategories.ToListAsync();
            return itemCategories;
        }

        public async Task<ItemCategoryResponse> GetItemCategoryByIdAsync(int id)
        {
            var itemCategory = await _context.ItemCategories.Where(ic => ic.Id == id).FirstOrDefaultAsync();
            if (itemCategory is null) return new ItemCategoryResponse(false, null!, "Item category not found");
            return new ItemCategoryResponse(true, itemCategory, "Load Success");
        }

        public async Task<GeneralResponse> UpdateItemCategoryAsync(int id, ItemCategoryDto itemCategoryDto)
        {
            var itemCategory = await _context.ItemCategories.Where(ic => ic.Id == id).FirstOrDefaultAsync();
            if (itemCategory is null) return new GeneralResponse(false, "Item category not found");
            
            itemCategory.Name = itemCategoryDto.Name;
            itemCategory.Description = itemCategoryDto.Description;
            itemCategory.UpdatedAt = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
                return new GeneralResponse(true, "Update Success");
            }
            catch(DbUpdateException)
            {
                return new GeneralResponse(false, "Update failed");
            }

        }
    }
}
