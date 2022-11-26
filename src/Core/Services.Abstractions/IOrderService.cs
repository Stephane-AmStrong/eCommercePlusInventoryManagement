using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        Task<IEnumerable<OrdersDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<OrderDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<OrderDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<OrderDto> CreateAsync(OrderDto order, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, OrderDto order, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}