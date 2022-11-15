using AutoMapper;
using Contracts;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
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

        public async Task<IEnumerable<OrdersReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _repositoryManager.OrderRepository.GetAllAsync(cancellationToken);

            var ordersDto = _mapper.Map<IEnumerable<OrdersReadDto>>(orders);

            return ordersDto;
        }

        public async Task<OrderReadDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _repositoryManager.OrderRepository.GetByIdAsync(id, cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(id);
            }

            var orderReadDto = _mapper.Map<OrderReadDto>(order);

            return orderReadDto;
        }

        public async Task<OrderReadDto> CreateAsync(OrderWriteDto orderWriteDto, CancellationToken cancellationToken = default)
        {
            var order = _mapper.Map<Order>(orderWriteDto);

            _repositoryManager.OrderRepository.Insert(order);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderReadDto>(order);
        }

        public async Task UpdateAsync(Guid id, OrderWriteDto orderWriteDto, CancellationToken cancellationToken = default)
        {
            var order = await _repositoryManager.OrderRepository.GetByIdAsync(id, cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(id);
            }

            _mapper.Map(orderWriteDto, order);

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