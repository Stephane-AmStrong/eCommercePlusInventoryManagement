using AutoMapper;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Contracts;
using Services.Abstractions;

namespace Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrdersDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _repositoryManager.OrderRepository.GetAllAsync(cancellationToken);

            var ordersDto = _mapper.Map<IEnumerable<OrdersDto>>(orders);

            return ordersDto;
        }

        public async Task<OrderDto> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _repositoryManager.OrderRepository.GetByIdAsync(id, cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(id);
            }

            var orderResponse = _mapper.Map<OrderDto>(order);

            return orderResponse;
        }

        public async Task<OrderDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _repositoryManager.OrderRepository.GetByIdAsync(id, cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(id);
            }

            var orderResponse = _mapper.Map<OrderDto>(order);

            return orderResponse;
        }

        public async Task<OrderDto> CreateAsync(OrderDto orderDto, CancellationToken cancellationToken = default)
        {
            var order = _mapper.Map<Order>(orderDto);

            var alreadyExist = await _repositoryManager.OrderRepository.ExistsAsync(order, cancellationToken);

            if (alreadyExist)
            {
                throw new OrderDuplicateException(order);
            }

            _repositoryManager.OrderRepository.Insert(order);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderDto>(order);
        }

        public async Task UpdateAsync(Guid id, OrderDto orderDto, CancellationToken cancellationToken = default)
        {
            var order = await _repositoryManager.OrderRepository.GetByIdAsync(id, cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(id);
            }

            _mapper.Map(orderDto, order);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _repositoryManager.OrderRepository.GetByIdAsync(id, cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(id);
            }

            _repositoryManager.OrderRepository.Remove(order);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}