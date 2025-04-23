﻿using Microsoft.AspNetCore.Mvc;
using SyddjursItemApi.Data;
using SyddjursItemApi.Models;

namespace SyddjursItemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("uploadItemCategory")]
        public async Task<IActionResult> UploadItemCategory([FromBody] ItemCategoryDto categoryDto)
        {
            if (categoryDto.Id == 0)
            {

                var category = new ItemCategory();
                category.Id = categoryDto.Id;
                category.Category = categoryDto.Category;

                await _context.ItemCategories.AddAsync(category);
            }
            else
            {
                // 🔄 Updating an existing Item category
                var existingCategory = await _context.ItemCategories.FindAsync(categoryDto.Id);
                if (existingCategory == null)
                    return NotFound($"Item with ID {categoryDto.Id} not found.");

                existingCategory.Category = categoryDto.Category; 

                _context.ItemCategories.Update(existingCategory);
            }

            await _context.SaveChangesAsync(); // ✅ Save here to get the generated Item category Id     
            return Ok();
        }

        [HttpGet("itemCategories")]
        public async Task<IActionResult> GetItemCategories()
        {
            var categoryList = _context.ItemCategories.ToList();
       
            var returnList = new List<ItemCategoryDto>();

            foreach (var category in categoryList)
            {
                var dto = new ItemCategoryDto();
                dto.Id = category.Id;
                dto.Category = category.Category;

                returnList.Add(dto);
            }

            return Ok(returnList);
        }
    }



}

