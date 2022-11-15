using Contracts;
using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IInventoryLevelService
    {
        Task<IEnumerable<InventoryLevelsReadDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<InventoryLevelReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<InventoryLevelReadDto> CreateAsync(InventoryLevelWriteDto inventoryLevel, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, InventoryLevelWriteDto inventoryLevel, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}