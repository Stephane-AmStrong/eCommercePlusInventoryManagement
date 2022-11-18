using AutoMapper;
using Contracts;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Contracts;
using Services.Abstractions;

namespace Services
{
    internal sealed class InventoryLevelService : IInventoryLevelService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public InventoryLevelService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        

        public async Task<IEnumerable<InventoryLevelsDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var inventoryLevels = await _repositoryManager.InventoryLevelRepository.GetAllAsync(cancellationToken);

            var inventoryLevelsDto = _mapper.Map<IEnumerable<InventoryLevelsDto>>(inventoryLevels);

            return inventoryLevelsDto;
        }


        public async Task<InventoryLevelDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = await _repositoryManager.InventoryLevelRepository.GetByIdAsync(id, cancellationToken);

            if (inventoryLevel is null)
            {
                throw new InventoryLevelNotFoundException(id);
            }

            var inventoryLevelResponse = _mapper.Map<InventoryLevelDto>(inventoryLevel);

            return inventoryLevelResponse;
        }


        public async Task<InventoryLevelDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = await _repositoryManager.InventoryLevelRepository.GetByIdAsync(id, cancellationToken);

            if (inventoryLevel is null)
            {
                throw new InventoryLevelNotFoundException(id);
            }

            var inventoryLevelResponse = _mapper.Map<InventoryLevelDto>(inventoryLevel);

            return inventoryLevelResponse;
        }


        public async Task<InventoryLevelDto> CreateAsync(InventoryLevelDto inventoryLevelDto, CancellationToken cancellationToken = default)
        {
            
            var inventoryLevel = _mapper.Map<InventoryLevel>(inventoryLevelDto);

            var alreadyExist = await _repositoryManager.InventoryLevelRepository.ExistsAsync(inventoryLevel, cancellationToken);

            if (alreadyExist)
            {
                throw new InventoryLevelDuplicateException(inventoryLevel);
            }

            _repositoryManager.InventoryLevelRepository.Insert(inventoryLevel);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<InventoryLevelDto>(inventoryLevel);
        }


        public async Task UpdateAsync(Guid id, InventoryLevelDto inventoryLevelDto, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = await _repositoryManager.InventoryLevelRepository.GetByIdAsync(id, cancellationToken);

            if (inventoryLevel is null)
            {
                throw new InventoryLevelNotFoundException(id);
            }

            _mapper.Map(inventoryLevelDto, inventoryLevel);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }


        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = await _repositoryManager.InventoryLevelRepository.GetByIdAsync(id, cancellationToken);

            if (inventoryLevel is null)
            {
                throw new InventoryLevelNotFoundException(id);
            }

            _repositoryManager.InventoryLevelRepository.Remove(inventoryLevel);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}