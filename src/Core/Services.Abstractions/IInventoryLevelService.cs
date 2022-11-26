using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IInventoryLevelService
    {
        Task<IEnumerable<InventoryLevelsDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<InventoryLevelDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<InventoryLevelDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<InventoryLevelDto> CreateAsync(InventoryLevelDto inventoryLevel, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, InventoryLevelDto inventoryLevel, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}