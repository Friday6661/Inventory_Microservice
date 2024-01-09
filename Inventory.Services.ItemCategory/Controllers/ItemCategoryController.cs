using System;
using AutoMapper;
using Inventory.Services.ItemCategoryAPI.Data;
using Inventory.Services.ItemCategoryAPI.Models;
using Inventory.Services.ItemCategoryAPI.Models.Dto;
using Inventory.Services.ItemCategoryAPI.Repository.Contracts;
using Inventory.Services.ItemCategoryAPI.Repository.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Services.ItemCategoryAPI.Controllers
{
    [Route("api/itemcategory")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategory _itemCategory;

        public ItemCategoryController(IItemCategory itemCategory)
        {
            _itemCategory = itemCategory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _itemCategory.GetItemCategoriesAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _itemCategory.GetItemCategoryByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ItemCategoryDto itemCategoryDto)
        {
            var response = await _itemCategory.CreateItemCategoryAsync(itemCategoryDto);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, ItemCategoryDto itemCategoryDto)
        {
            var response = await _itemCategory.UpdateItemCategoryAsync(id, itemCategoryDto);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _itemCategory.DeleteItemCategoryAsync(id);
            return Ok(response);
        }
    }
}
