using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IAppUserService AppUserService { get; }
        IInventoryLevelService InventoryLevelService { get; }
        IItemCategoryService ItemCategoryService { get; }
        IItemService ItemService { get; }
        IOrderItemService OrderItemService { get; }
        IOrderService OrderService { get; }
    }
}
