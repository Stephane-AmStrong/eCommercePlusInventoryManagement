using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Insert(Order order);
        void Remove(Order order);
    }
}
