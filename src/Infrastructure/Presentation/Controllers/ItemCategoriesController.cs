using Contracts;
using DataTransfertObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/itemCategories")]
    public class ItemCategoriesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ItemCategoriesController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetItemCategories(CancellationToken cancellationToken)
        {
            var itemCategories = await _serviceManager.ItemCategoryService.GetAllAsync(cancellationToken);

            return Ok(itemCategories);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetItemCategoryById(Guid id, CancellationToken cancellationToken)
        {
            var itemCategoryDto = await _serviceManager.ItemCategoryService.GetByIdAsync(id, cancellationToken);

            return Ok(itemCategoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemCategory([FromBody] ItemCategoryWriteDto itemCategoryWriteDto)
        {
            var itemCategoryDto = await _serviceManager.ItemCategoryService.CreateAsync(itemCategoryWriteDto);

            return CreatedAtAction(nameof(GetItemCategoryById), new { id = itemCategoryDto.Id }, itemCategoryDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateItemCategory(Guid id, [FromBody] ItemCategoryWriteDto itemCategoryWriteDto, CancellationToken cancellationToken)
        {
            await _serviceManager.ItemCategoryService.UpdateAsync(id, itemCategoryWriteDto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteItemCategory(Guid id, CancellationToken cancellationToken)
        {
            await _serviceManager.ItemCategoryService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
