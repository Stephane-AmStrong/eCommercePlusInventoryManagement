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
    internal sealed class InventoryLevelRepository : IInventoryLevelRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public InventoryLevelRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<InventoryLevel>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.InventoryLevels.Include(x => x.Item).ToListAsync(cancellationToken);

        public async Task<InventoryLevel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.InventoryLevels.Include(x => x.Item).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void Insert(InventoryLevel inventoryLevel) => _dbContext.InventoryLevels.Add(inventoryLevel);

        public void Remove(InventoryLevel inventoryLevel) => _dbContext.InventoryLevels.Remove(inventoryLevel);
    }
}
