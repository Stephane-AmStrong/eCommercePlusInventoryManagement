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
    internal sealed class ItemRepository : IItemRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ItemRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Items
                .Include(x => x.ItemCategory)
                .Include(x => x.InventoryLevels)
                .Include(x => x.OrderItems)
                .ToListAsync(cancellationToken);
        }
            

        public async Task<Item> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Items
                .Include(x => x.ItemCategory)
                .Include(x => x.InventoryLevels)
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Insert(Item item) => _dbContext.Items.Add(item);

        public void Remove(Item item) => _dbContext.Items.Remove(item);
    }
}
