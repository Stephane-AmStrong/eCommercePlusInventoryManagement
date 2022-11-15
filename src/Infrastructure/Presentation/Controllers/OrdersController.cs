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
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrdersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
        {
            var orders = await _serviceManager.OrderService.GetAllAsync(cancellationToken);

            return Ok(orders);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id, CancellationToken cancellationToken)
        {
            var orderDto = await _serviceManager.OrderService.GetByIdAsync(id, cancellationToken);

            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderWriteDto orderWriteDto)
        {
            var orderDto = await _serviceManager.OrderService.CreateAsync(orderWriteDto);

            return CreatedAtAction(nameof(GetOrderById), new { id = orderDto.Id }, orderDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderWriteDto orderWriteDto, CancellationToken cancellationToken)
        {
            await _serviceManager.OrderService.UpdateAsync(id, orderWriteDto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrder(Guid id, CancellationToken cancellationToken)
        {
            await _serviceManager.OrderService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
