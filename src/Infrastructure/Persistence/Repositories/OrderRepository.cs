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
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public OrderRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Orders.Include(x => x.OrderItems).ToListAsync(cancellationToken);

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void Insert(Order order) => _dbContext.Orders.Add(order);

        public void Remove(Order order) => _dbContext.Orders.Remove(order);
    }
}
