using Contracts;
using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemsReadDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<OrderItemReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<OrderItemReadDto> CreateAsync(OrderItemWriteDto orderItem, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, OrderItemWriteDto orderItem, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}