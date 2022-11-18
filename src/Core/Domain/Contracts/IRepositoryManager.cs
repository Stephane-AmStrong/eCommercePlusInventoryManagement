using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IRepositoryManager
    {
        IAppUserRepository AppUserRepository { get; }
        IInventoryLevelRepository InventoryLevelRepository { get; }
        IItemCategoryRepository ItemCategoryRepository { get; }
        IItemRepository ItemRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IOrderRepository OrderRepository { get; }

        IOwnerRepository OwnerRepository { get; }
        IAccountRepository AccountRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
