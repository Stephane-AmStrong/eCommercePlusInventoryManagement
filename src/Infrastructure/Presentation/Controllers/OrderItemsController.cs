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
    [Route("api/orderItems")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrderItemsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetOrderItems(CancellationToken cancellationToken)
        {
            var orderItems = await _serviceManager.OrderItemService.GetAllAsync(cancellationToken);

            return Ok(orderItems);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderItemById(Guid id, CancellationToken cancellationToken)
        {
            var orderItemDto = await _serviceManager.OrderItemService.GetByIdAsync(id, cancellationToken);

            return Ok(orderItemDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItemWriteDto orderItemWriteDto)
        {
            var orderItemDto = await _serviceManager.OrderItemService.CreateAsync(orderItemWriteDto);

            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderItemDto.Id }, orderItemDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateOrderItem(Guid id, [FromBody] OrderItemWriteDto orderItemWriteDto, CancellationToken cancellationToken)
        {
            await _serviceManager.OrderItemService.UpdateAsync(id, orderItemWriteDto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id, CancellationToken cancellationToken)
        {
            await _serviceManager.OrderItemService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
