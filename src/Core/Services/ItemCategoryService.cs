using AutoMapper;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Contracts;
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

        public async Task<IEnumerable<ItemCategoriesDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var itemCategories = await _repositoryManager.ItemCategoryRepository.GetAllAsync(cancellationToken);

            var itemCategoriesDto = _mapper.Map<IEnumerable<ItemCategoriesDto>>(itemCategories);

            return itemCategoriesDto;
        }

        public async Task<ItemCategoryDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var itemCategory = await _repositoryManager.ItemCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (itemCategory is null)
            {
                throw new ItemCategoryNotFoundException(id);
            }

            var itemCategoryResponse = _mapper.Map<ItemCategoryDto>(itemCategory);

            return itemCategoryResponse;
        }

        public async Task<ItemCategoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var itemCategory = await _repositoryManager.ItemCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (itemCategory is null)
            {
                throw new ItemCategoryNotFoundException(id);
            }

            var itemCategoryWrite = _mapper.Map<ItemCategoryDto>(itemCategory);

            return itemCategoryWrite;
        }

        public async Task<ItemCategoryDto> CreateAsync(ItemCategoryDto itemCategoryDto, CancellationToken cancellationToken = default)
        {
            var itemCategory = _mapper.Map<ItemCategory>(itemCategoryDto);

            var alreadyExist = await _repositoryManager.ItemCategoryRepository.ExistsAsync(itemCategory, cancellationToken);

            if (alreadyExist)
            {
                throw new ItemCategoryDuplicateException(itemCategory);
            }

            _repositoryManager.ItemCategoryRepository.Insert(itemCategory);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ItemCategoryDto>(itemCategory);
        }

        public async Task UpdateAsync(Guid id, ItemCategoryDto itemCategoryDto, CancellationToken cancellationToken = default)
        {
            var itemCategory = await _repositoryManager.ItemCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (itemCategory is null)
            {
                throw new ItemCategoryNotFoundException(id);
            }

            _mapper.Map(itemCategoryDto, itemCategory);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var itemCategory = await _repositoryManager.ItemCategoryRepository.GetByIdAsync(id, cancellationToken);

            if (itemCategory is null)
            {
                throw new ItemCategoryNotFoundException(id);
            }

            _repositoryManager.ItemCategoryRepository.Remove(itemCategory);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}