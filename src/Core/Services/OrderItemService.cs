using AutoMapper;
using Contracts;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Contracts;
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

        public async Task<IEnumerable<OrderItemsDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orderItems = await _repositoryManager.OrderItemRepository.GetAllAsync(cancellationToken);

            var orderItemsDto = _mapper.Map<IEnumerable<OrderItemsDto>>(orderItems);

            return orderItemsDto;
        }

        public async Task<OrderItemDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var orderItem = await _repositoryManager.OrderItemRepository.GetByIdAsync(id, cancellationToken);

            if (orderItem is null)
            {
                throw new OrderItemNotFoundException(id);
            }

            var orderItemResponse = _mapper.Map<OrderItemDto>(orderItem);

            return orderItemResponse;
        }

        public async Task<OrderItemDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var orderItem = await _repositoryManager.OrderItemRepository.GetByIdAsync(id, cancellationToken);

            if (orderItem is null)
            {
                throw new OrderItemNotFoundException(id);
            }

            var orderItemResponse = _mapper.Map<OrderItemDto>(orderItem);

            return orderItemResponse;
        }

        public async Task<OrderItemDto> CreateAsync(OrderItemDto orderItemDto, CancellationToken cancellationToken = default)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);

            var alreadyExist = await _repositoryManager.OrderItemRepository.ExistsAsync(orderItem, cancellationToken);

            if (alreadyExist)
            {
                throw new OrderItemDuplicateException(orderItem);
            }

            _repositoryManager.OrderItemRepository.Insert(orderItem);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task UpdateAsync(Guid id, OrderItemDto orderItemDto, CancellationToken cancellationToken = default)
        {
            var orderItem = await _repositoryManager.OrderItemRepository.GetByIdAsync(id, cancellationToken);

            if (orderItem is null)
            {
                throw new OrderItemNotFoundException(id);
            }

            _mapper.Map(orderItemDto, orderItem);

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