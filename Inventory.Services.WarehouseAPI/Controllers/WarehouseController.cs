using Inventory.Services.WarehouseAPI.Models.Dto;
using Inventory.Services.WarehouseAPI.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Services.WarehouseAPI.Controllers
{
    [Route("api/warehouse")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouse _warehouse;

        public WarehouseController(IWarehouse warehouse)
        {
            _warehouse = warehouse;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(WarehouseDto warehouse)
        {
            var response = await _warehouse.CreateWarehouseAsync(warehouse);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, WarehouseDto warehouse)
        {
            var response = await _warehouse.UpdateWarehouseAsync(id, warehouse);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _warehouse.GetWarehouseAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _warehouse.GetWarehouseByIdAsync(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _warehouse.DeleteWarehouseAsync(id);
            return Ok(response);
        }
    }
}
