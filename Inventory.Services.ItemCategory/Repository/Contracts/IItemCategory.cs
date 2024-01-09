using Inventory.Services.ItemCategoryAPI.Models;
using Inventory.Services.ItemCategoryAPI.Models.Dto;
using static Inventory.Services.ItemCategoryAPI.Models.Dto.Response;

namespace Inventory.Services.ItemCategoryAPI.Repository.Contracts
{
    public interface IItemCategory
    {
        Task<ICollection<ItemCategory>> GetItemCategoriesAsync();
        Task<ItemCategoryResponse> GetItemCategoryByIdAsync(int id);
        Task<GeneralResponse> CreateItemCategoryAsync(ItemCategoryDto itemCategory);
        Task<GeneralResponse> UpdateItemCategoryAsync(int id, ItemCategoryDto itemCategory);
        Task<GeneralResponse> DeleteItemCategoryAsync(int id);
    }
}
