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
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ItemsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetItems(CancellationToken cancellationToken)
        {
            var items = await _serviceManager.ItemService.GetAllAsync(cancellationToken);

            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetItemById(Guid id, CancellationToken cancellationToken)
        {
            var itemDto = await _serviceManager.ItemService.GetByIdAsync(id, cancellationToken);

            return Ok(itemDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ItemWriteDto itemWriteDto)
        {
            var itemDto = await _serviceManager.ItemService.CreateAsync(itemWriteDto);

            return CreatedAtAction(nameof(GetItemById), new { id = itemDto.Id }, itemDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] ItemWriteDto itemWriteDto, CancellationToken cancellationToken)
        {
            await _serviceManager.ItemService.UpdateAsync(id, itemWriteDto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteItem(Guid id, CancellationToken cancellationToken)
        {
            await _serviceManager.ItemService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
