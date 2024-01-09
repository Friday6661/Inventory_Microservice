using System.ComponentModel.DataAnnotations;

namespace Inventory.Services.ItemAPI.Models.Dto
{
    public class ItemDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
