namespace Inventory.Services.WarehouseAPI.Models
{
    public class Warehouse
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
