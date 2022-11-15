using Contracts;
using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        Task<IEnumerable<OrdersReadDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<OrderReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<OrderReadDto> CreateAsync(OrderWriteDto order, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, OrderWriteDto order, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}