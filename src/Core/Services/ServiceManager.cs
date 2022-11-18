using AutoMapper;
using Domain.Contracts;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAppUserService> _lazyAppUserService;
        private readonly Lazy<IInventoryLevelService> _lazyInventoryLevelService;
        private readonly Lazy<IItemCategoryService> _lazyItemCategoryService;
        private readonly Lazy<IItemService> _lazyItemService;
        private readonly Lazy<IOrderItemService> _lazyOrderItemService;
        private readonly Lazy<IOrderService> _lazyOrderService;

        private readonly Lazy<IOwnerService> _lazyOwnerService;
        private readonly Lazy<IAccountService> _lazyAccountService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyAppUserService = new Lazy<IAppUserService>(() => new AppUserService(repositoryManager, mapper));
            _lazyInventoryLevelService = new Lazy<IInventoryLevelService>(() => new InventoryLevelService(repositoryManager, mapper));
            _lazyItemCategoryService = new Lazy<IItemCategoryService>(() => new ItemCategoryService(repositoryManager, mapper));
            _lazyItemService = new Lazy<IItemService>(() => new ItemService(repositoryManager, mapper));
            _lazyOrderItemService = new Lazy<IOrderItemService>(() => new OrderItemService(repositoryManager, mapper));
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, mapper));

            _lazyOwnerService = new Lazy<IOwnerService>(() => new OwnerService(repositoryManager));
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager));
        }

        public IAppUserService AppUserService => _lazyAppUserService.Value;
        public IInventoryLevelService InventoryLevelService => _lazyInventoryLevelService.Value;
        public IItemCategoryService ItemCategoryService => _lazyItemCategoryService.Value;
        public IItemService ItemService => _lazyItemService.Value;
        public IOrderItemService OrderItemService => _lazyOrderItemService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;

        public IOwnerService OwnerService => _lazyOwnerService.Value;
        public IAccountService AccountService => _lazyAccountService.Value;
    }
}
