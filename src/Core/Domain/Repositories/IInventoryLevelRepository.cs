using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IInventoryLevelRepository
    {
        Task<IEnumerable<InventoryLevel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<InventoryLevel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Insert(InventoryLevel inventoryLevel);
        void Remove(InventoryLevel inventoryLevel);
    }
}
