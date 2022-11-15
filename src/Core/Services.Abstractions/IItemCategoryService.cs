using Contracts;
using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IItemCategoryService
    {
        Task<IEnumerable<ItemCategoriesReadDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ItemCategoryReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<ItemCategoryReadDto> CreateAsync(ItemCategoryWriteDto item, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, ItemCategoryWriteDto item, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}