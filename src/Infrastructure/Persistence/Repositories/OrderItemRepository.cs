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
    internal sealed class OrderItemRepository : IOrderItemRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public OrderItemRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<OrderItem> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.OrderItems.Include(x => x.Order).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        public async Task<OrderItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext.OrderItems.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);


        public async Task<bool> ExistsAsync(OrderItem orderItem, CancellationToken cancellationToken = default) =>
            await _dbContext.OrderItems.AnyAsync(x => 
                x.Qte == orderItem.Qte &&
                x.Total == orderItem.Total &&
                x.OrderId == orderItem.OrderId &&
                x.ItemId == orderItem.ItemId
            , cancellationToken);

        public async Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.OrderItems.Include(x => x.Order).ToListAsync(cancellationToken);
        public void Insert(OrderItem orderItem) => _dbContext.OrderItems.Add(orderItem);

        public void Remove(OrderItem orderItem) => _dbContext.OrderItems.Remove(orderItem);
    }
}
