using AutoMapper;
using Contracts;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal sealed class ItemCategoryService : IItemCategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ItemCategoryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemCategoriesReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var inventoryLevels = await _repositoryManager.ItemCategoryRepository.GetAllAsync(cancellationToken);

            var inventoryLevelsDto = _mapper.Map<IEnumerable<ItemCategoriesReadDto>>(inventoryLevels);

            return inventoryLevelsDto;
        }

        public async Task<ItemCategoryReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = await _repositoryManager.ItemCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (inventoryLevel is null)
            {
                throw new ItemCategoryNotFoundException(id);
            }

            var inventoryLevelReadDto = _mapper.Map<ItemCategoryReadDto>(inventoryLevel);

            return inventoryLevelReadDto;
        }

        public async Task<ItemCategoryReadDto> CreateAsync(ItemCategoryWriteDto inventoryLevelWriteDto, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = _mapper.Map<ItemCategory>(inventoryLevelWriteDto);

            _repositoryManager.ItemCategoryRepository.Insert(inventoryLevel);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ItemCategoryReadDto>(inventoryLevel);
        }

        public async Task UpdateAsync(Guid id, ItemCategoryWriteDto inventoryLevelWriteDto, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = await _repositoryManager.ItemCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (inventoryLevel is null)
            {
                throw new ItemCategoryNotFoundException(id);
            }

            _mapper.Map(inventoryLevelWriteDto, inventoryLevel);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = await _repositoryManager.ItemCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (inventoryLevel is null)
            {
                throw new ItemCategoryNotFoundException(id);
            }

            _repositoryManager.ItemCategoryRepository.Remove(inventoryLevel);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}