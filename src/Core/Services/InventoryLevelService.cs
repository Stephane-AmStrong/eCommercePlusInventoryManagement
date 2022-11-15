using AutoMapper;
using Contracts;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
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

        public async Task<IEnumerable<InventoryLevelsReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var inventoryLevels = await _repositoryManager.InventoryLevelRepository.GetAllAsync(cancellationToken);

            var inventoryLevelsDto = _mapper.Map<IEnumerable<InventoryLevelsReadDto>>(inventoryLevels);

            return inventoryLevelsDto;
        }

        public async Task<InventoryLevelReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = await _repositoryManager.InventoryLevelRepository.GetByIdAsync(id, cancellationToken);

            if (inventoryLevel is null)
            {
                throw new InventoryLevelNotFoundException(id);
            }

            var inventoryLevelReadDto = _mapper.Map<InventoryLevelReadDto>(inventoryLevel);

            return inventoryLevelReadDto;
        }

        public async Task<InventoryLevelReadDto> CreateAsync(InventoryLevelWriteDto inventoryLevelWriteDto, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = _mapper.Map<InventoryLevel>(inventoryLevelWriteDto);

            _repositoryManager.InventoryLevelRepository.Insert(inventoryLevel);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<InventoryLevelReadDto>(inventoryLevel);
        }

        public async Task UpdateAsync(Guid id, InventoryLevelWriteDto inventoryLevelWriteDto, CancellationToken cancellationToken = default)
        {
            var inventoryLevel = await _repositoryManager.InventoryLevelRepository.GetByIdAsync(id, cancellationToken);

            if (inventoryLevel is null)
            {
                throw new InventoryLevelNotFoundException(id);
            }

            _mapper.Map(inventoryLevelWriteDto, inventoryLevel);

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