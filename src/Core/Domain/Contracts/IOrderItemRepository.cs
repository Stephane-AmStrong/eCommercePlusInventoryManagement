using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<OrderItem> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<OrderItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(OrderItem orderItem, CancellationToken cancellationToken = default);

        void Insert(OrderItem orderItem);
        void Remove(OrderItem orderItem);
    }
}
