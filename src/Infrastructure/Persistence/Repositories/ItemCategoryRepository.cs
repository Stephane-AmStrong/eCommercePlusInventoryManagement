using Domain.Entities;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class ItemCategoryRepository : IItemCategoryRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ItemCategoryRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<ItemCategory>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.ItemCategories.Include(x => x.Items).ToListAsync(cancellationToken);

        public async Task<ItemCategory> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.ItemCategories.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        public async Task<ItemCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.ItemCategories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<bool> ExistsAsync(ItemCategory itemCategory, CancellationToken cancellationToken = default) =>
            await _dbContext.ItemCategories.AnyAsync(x =>
                x.Name == itemCategory.Name &&
                x.Description == itemCategory.Description
            , cancellationToken);

        public void Insert(ItemCategory itemCategory) => _dbContext.ItemCategories.Add(itemCategory);

        public void Remove(ItemCategory itemCategory) => _dbContext.ItemCategories.Remove(itemCategory);
    }
}
