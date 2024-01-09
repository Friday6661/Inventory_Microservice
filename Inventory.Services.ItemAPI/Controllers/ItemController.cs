using Inventory.Services.ItemAPI.Models.Dto;
using Inventory.Services.ItemAPI.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Services.ItemAPI.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItem _item;

        public ItemController(IItem item)
        {
            _item = item;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _item.GetItemAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _item.GetItemByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ItemDto item)
        {
            var response = await _item.CreateItemAsync(item);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, ItemDto item)
        {
            var response = await _item.UpdateItemAsync(id, item);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _item.DeleteItemAsync(id);
            return Ok(response);
        }
    }
}
