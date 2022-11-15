using AutoMapper;
using Contracts;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
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

        public async Task<IEnumerable<ItemsReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ItemRepository.GetAllAsync(cancellationToken);

            var itemsDto = _mapper.Map<IEnumerable<ItemsReadDto>>(items);

            return itemsDto;
        }

        public async Task<ItemReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ItemRepository.GetByIdAsync(id, cancellationToken);

            if (item is null)
            {
                throw new ItemNotFoundException(id);
            }

            var itemReadDto = _mapper.Map<ItemReadDto>(item);

            return itemReadDto;
        }

        public async Task<ItemReadDto> CreateAsync(ItemWriteDto itemWriteDto, CancellationToken cancellationToken = default)
        {
            var item = _mapper.Map<Item>(itemWriteDto);

            _repositoryManager.ItemRepository.Insert(item);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ItemReadDto>(item);
        }

        public async Task UpdateAsync(Guid id, ItemWriteDto itemWriteDto, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ItemRepository.GetByIdAsync(id, cancellationToken);

            if (item is null)
            {
                throw new ItemNotFoundException(id);
            }

            _mapper.Map(itemWriteDto, item);

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