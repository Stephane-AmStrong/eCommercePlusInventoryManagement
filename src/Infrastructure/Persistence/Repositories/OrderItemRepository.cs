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
    internal sealed class OrderItemRepository : IOrderItemRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public OrderItemRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.OrderItems.Include(x => x.Order).ToListAsync(cancellationToken);

        public async Task<OrderItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.OrderItems.Include(x => x.Order).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void Insert(OrderItem order) => _dbContext.OrderItems.Add(order);

        public void Remove(OrderItem order) => _dbContext.OrderItems.Remove(order);
    }
}
