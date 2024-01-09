using Inventory.Services.ItemAPI.Models;
using Inventory.Services.ItemAPI.Models.Dto;
using static Inventory.Services.ItemAPI.Models.Dto.Response;

namespace Inventory.Services.ItemAPI.Repository.Contracts
{
    public interface IItem
    {
        Task<ICollection<Item>> GetItemAsync();
        Task<ItemResponse> GetItemByIdAsync(int id);
        Task<GeneralResponse> CreateItemAsync(ItemDto itemDto);
        Task<GeneralResponse> UpdateItemAsync(int id, ItemDto itemDto);
        Task<GeneralResponse> DeleteItemAsync(int id);
    }
}
