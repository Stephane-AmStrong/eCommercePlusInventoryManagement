using Contracts;
using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IItemService
    {
        Task<IEnumerable<ItemsDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ItemDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<ItemDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<ItemDto> CreateAsync(ItemDto item, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, ItemDto item, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}