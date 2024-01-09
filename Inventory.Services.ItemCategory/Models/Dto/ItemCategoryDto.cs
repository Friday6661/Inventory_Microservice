using System.ComponentModel.DataAnnotations;

namespace Inventory.Services.ItemCategoryAPI.Models.Dto
{
    public class ItemCategoryDto
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
