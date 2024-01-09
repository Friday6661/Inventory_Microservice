using Inventory.Services.WarehouseAPI.Models;
using Inventory.Services.WarehouseAPI.Models.Dto;
using static Inventory.Services.WarehouseAPI.Models.Dto.Response;

namespace Inventory.Services.WarehouseAPI.Repository.Contracts
{
    public interface IWarehouse
    {
        Task<ICollection<Warehouse>> GetWarehouseAsync();
        Task<WarehouseResponse> GetWarehouseByIdAsync(int id);
        Task<GeneralResponse> CreateWarehouseAsync(WarehouseDto warehouseDto);
        Task<GeneralResponse> UpdateWarehouseAsync(int id, WarehouseDto warehouseDto);
        Task<GeneralResponse> DeleteWarehouseAsync(int id);
    }
}
