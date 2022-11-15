using Contracts;
using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IItemService
    {
        Task<IEnumerable<ItemsReadDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ItemReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<ItemReadDto> CreateAsync(ItemWriteDto item, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, ItemWriteDto item, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}