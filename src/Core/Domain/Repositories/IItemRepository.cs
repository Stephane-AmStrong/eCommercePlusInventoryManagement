using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Item> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Insert(Item item);
        void Remove(Item item);
    }
}
