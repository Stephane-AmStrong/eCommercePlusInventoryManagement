using AutoMapper;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Contracts;
using Services.Abstractions;

namespace Services
{
    internal sealed class ItemService : IItemService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ItemService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemsDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ItemRepository.GetAllAsync(cancellationToken);

            var itemsDto = _mapper.Map<IEnumerable<ItemsDto>>(items);

            return itemsDto;
        }

        public async Task<ItemDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ItemRepository.GetByIdAsync(id, cancellationToken);

            if (item is null)
            {
                throw new ItemNotFoundException(id);
            }

            var itemResponse = _mapper.Map<ItemDto>(item);

            return itemResponse;
        }

        public async Task<ItemDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ItemRepository.GetByIdAsync(id, cancellationToken);

            if (item is null)
            {
                throw new ItemNotFoundException(id);
            }

            var itemResponse = _mapper.Map<ItemDto>(item);

            return itemResponse;
        }

        public async Task<ItemDto> CreateAsync(ItemDto itemDto, CancellationToken cancellationToken = default)
        {
            var item = _mapper.Map<Item>(itemDto);

            var alreadyExist = await _repositoryManager.ItemRepository.ExistsAsync(item, cancellationToken);

            if (alreadyExist)
            {
                throw new ItemDuplicateException(item);
            }

            _repositoryManager.ItemRepository.Insert(item);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ItemDto>(item);
        }

        public async Task UpdateAsync(Guid id, ItemDto itemDto, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ItemRepository.GetByIdAsync(id, cancellationToken);

            if (item is null)
            {
                throw new ItemNotFoundException(id);
            }

            _mapper.Map(itemDto, item);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ItemRepository.GetByIdAsync(id, cancellationToken);

            if (item is null)
            {
                throw new ItemNotFoundException(id);
            }

            _repositoryManager.ItemRepository.Remove(item);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}