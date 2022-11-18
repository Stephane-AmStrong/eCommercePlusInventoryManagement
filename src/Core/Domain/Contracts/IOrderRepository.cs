using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Order> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Order order, CancellationToken cancellationToken = default);

        void Insert(Order order);
        void Remove(Order order);
    }
}
