using AutoMapper;
using Contracts;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal sealed class AppUserService : IAppUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AppUserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUsersReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var appUsers = await _repositoryManager.AppUserRepository.GetAllAsync(cancellationToken);

            var appUsersDto = _mapper.Map<IEnumerable<AppUsersReadDto>>(appUsers);

            return appUsersDto;
        }

        public async Task<AppUserReadDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var appUser = await _repositoryManager.AppUserRepository.GetByIdAsync(id, cancellationToken);

            if (appUser is null)
            {
                throw new AppUserNotFoundException(id);
            }

            var appUserReadDto = _mapper.Map<AppUserReadDto>(appUser);

            return appUserReadDto;
        }

        public async Task<AppUserReadDto> CreateAsync(AppUserWriteDto appUserWriteDto, CancellationToken cancellationToken = default)
        {
            var appUser = _mapper.Map<AppUser>(appUserWriteDto);

            _repositoryManager.AppUserRepository.Insert(appUser);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AppUserReadDto>(appUser);
        }

        public async Task UpdateAsync(string id, AppUserWriteDto appUserWriteDto, CancellationToken cancellationToken = default)
        {
            var appUser = await _repositoryManager.AppUserRepository.GetByIdAsync(id, cancellationToken);

            if (appUser is null)
            {
                throw new AppUserNotFoundException(id);
            }

            _mapper.Map(appUserWriteDto, appUser);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var appUser = await _repositoryManager.AppUserRepository.GetByIdAsync(id, cancellationToken);

            if (appUser is null)
            {
                throw new AppUserNotFoundException(id);
            }

            _repositoryManager.AppUserRepository.Remove(appUser);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}