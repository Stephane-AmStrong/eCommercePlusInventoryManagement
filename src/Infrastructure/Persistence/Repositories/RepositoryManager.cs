using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IAppUserRepository> _lazyAppUserRepository;
        private readonly Lazy<IInventoryLevelRepository> _lazyInventoryLevelRepository;
        private readonly Lazy<IItemCategoryRepository> _lazyItemCategoryRepository;
        private readonly Lazy<IItemRepository> _lazyItemRepository;
        private readonly Lazy<IOrderItemRepository> _lazyOrderItemRepository;
        private readonly Lazy<IOrderRepository> _lazyOrderRepository;

        private readonly Lazy<IOwnerRepository> _lazyOwnerRepository;
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyAppUserRepository = new Lazy<IAppUserRepository>(() => new AppUserRepository(dbContext));
            _lazyInventoryLevelRepository = new Lazy<IInventoryLevelRepository>(() => new InventoryLevelRepository(dbContext));
            _lazyItemCategoryRepository = new Lazy<IItemCategoryRepository>(() => new ItemCategoryRepository(dbContext));
            _lazyItemRepository = new Lazy<IItemRepository>(() => new ItemRepository(dbContext));
            _lazyOrderItemRepository = new Lazy<IOrderItemRepository>(() => new OrderItemRepository(dbContext));
            _lazyOrderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(dbContext));

            _lazyOwnerRepository = new Lazy<IOwnerRepository>(() => new OwnerRepository(dbContext));
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IAppUserRepository AppUserRepository => _lazyAppUserRepository.Value;
        public IInventoryLevelRepository InventoryLevelRepository => _lazyInventoryLevelRepository.Value;
        public IItemCategoryRepository ItemCategoryRepository => _lazyItemCategoryRepository.Value;
        public IItemRepository ItemRepository => _lazyItemRepository.Value;
        public IOrderItemRepository OrderItemRepository => _lazyOrderItemRepository.Value;
        public IOrderRepository OrderRepository => _lazyOrderRepository.Value;

        public IOwnerRepository OwnerRepository => _lazyOwnerRepository.Value;
        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
