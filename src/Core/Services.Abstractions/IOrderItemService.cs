using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemsDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<OrderItemDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<OrderItemDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<OrderItemDto> CreateAsync(OrderItemDto orderItem, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, OrderItemDto orderItem, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}