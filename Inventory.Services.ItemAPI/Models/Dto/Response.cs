namespace Inventory.Services.ItemAPI.Models.Dto
{
    public class Response
    {
        public record class GeneralResponse(bool Flag, string Message);
        public record class ItemResponse(bool Flag, Item Item, string Message);
    }
}
