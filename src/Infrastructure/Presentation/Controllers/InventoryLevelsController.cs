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
    [Route("api/inventoryLevels")]
    public class InventoryLevelsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public InventoryLevelsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetInventoryLevels(CancellationToken cancellationToken)
        {
            var inventoryLevels = await _serviceManager.InventoryLevelService.GetAllAsync(cancellationToken);

            return Ok(inventoryLevels);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetInventoryLevelById(Guid id, CancellationToken cancellationToken)
        {
            var inventoryLevelDto = await _serviceManager.InventoryLevelService.GetByIdAsync(id, cancellationToken);

            return Ok(inventoryLevelDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventoryLevel([FromBody] InventoryLevelWriteDto inventoryLevelWriteDto)
        {
            var inventoryLevelDto = await _serviceManager.InventoryLevelService.CreateAsync(inventoryLevelWriteDto);

            return CreatedAtAction(nameof(GetInventoryLevelById), new { id = inventoryLevelDto.Id }, inventoryLevelDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateInventoryLevel(Guid id, [FromBody] InventoryLevelWriteDto inventoryLevelWriteDto, CancellationToken cancellationToken)
        {
            await _serviceManager.InventoryLevelService.UpdateAsync(id, inventoryLevelWriteDto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteInventoryLevel(Guid id, CancellationToken cancellationToken)
        {
            await _serviceManager.InventoryLevelService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
