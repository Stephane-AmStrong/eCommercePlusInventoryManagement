using Domain.Entities;
using Domain.Repositories;
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

        public async Task<ItemCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.ItemCategories.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void Insert(ItemCategory inventoryLevel) => _dbContext.ItemCategories.Add(inventoryLevel);

        public void Remove(ItemCategory inventoryLevel) => _dbContext.ItemCategories.Remove(inventoryLevel);
    }
}
