using AutoMapper;
using Contracts;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal sealed class OrderItemService : IOrderItemService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderItemService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemsReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orderItems = await _repositoryManager.OrderItemRepository.GetAllAsync(cancellationToken);

            var orderItemsDto = _mapper.Map<IEnumerable<OrderItemsReadDto>>(orderItems);

            return orderItemsDto;
        }

        public async Task<OrderItemReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var orderItem = await _repositoryManager.OrderItemRepository.GetByIdAsync(id, cancellationToken);

            if (orderItem is null)
            {
                throw new OrderItemNotFoundException(id);
            }

            var orderItemReadDto = _mapper.Map<OrderItemReadDto>(orderItem);

            return orderItemReadDto;
        }

        public async Task<OrderItemReadDto> CreateAsync(OrderItemWriteDto orderItemWriteDto, CancellationToken cancellationToken = default)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemWriteDto);

            _repositoryManager.OrderItemRepository.Insert(orderItem);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderItemReadDto>(orderItem);
        }

        public async Task UpdateAsync(Guid id, OrderItemWriteDto orderItemWriteDto, CancellationToken cancellationToken = default)
        {
            var orderItem = await _repositoryManager.OrderItemRepository.GetByIdAsync(id, cancellationToken);

            if (orderItem is null)
            {
                throw new OrderItemNotFoundException(id);
            }

            _mapper.Map(orderItemWriteDto, orderItem);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var orderItem = await _repositoryManager.OrderItemRepository.GetByIdAsync(id, cancellationToken);

            if (orderItem is null)
            {
                throw new OrderItemNotFoundException(id);
            }

            _repositoryManager.OrderItemRepository.Remove(orderItem);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}