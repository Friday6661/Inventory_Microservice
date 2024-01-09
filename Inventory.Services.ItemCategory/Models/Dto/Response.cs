namespace Inventory.Services.ItemCategoryAPI.Models.Dto
{
    public class Response
    {
        public record class GeneralResponse(bool Flag, string Message);
        public record class ItemCategoryResponse(bool Flag, ItemCategory ItemCategory, string Message);
    }
}
