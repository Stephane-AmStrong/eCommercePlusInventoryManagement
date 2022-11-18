using Contracts;
using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IItemCategoryService
    {
        Task<IEnumerable<ItemCategoriesDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ItemCategoryDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<ItemCategoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<ItemCategoryDto> CreateAsync(ItemCategoryDto item, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid id, ItemCategoryDto item, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}