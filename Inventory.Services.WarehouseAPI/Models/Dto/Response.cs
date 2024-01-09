namespace Inventory.Services.WarehouseAPI.Models.Dto
{
    public class Response
    {
        public record class GeneralResponse(bool Flag, string Message);
        public record class WarehouseResponse(bool Flag, Warehouse Warehouse, string Message);
    }
}
