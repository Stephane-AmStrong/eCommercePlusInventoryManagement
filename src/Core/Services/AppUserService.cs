using AutoMapper;
using DataTransfertObjects;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Contracts;
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

        public async Task<IEnumerable<AppUsersDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var appUsers = await _repositoryManager.AppUserRepository.GetAllAsync(cancellationToken);

            var appUsersDto = _mapper.Map<IEnumerable<AppUsersDto>>(appUsers);

            return appUsersDto;
        }

        public async Task<AppUserDto> GetDetailsByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var appUser = await _repositoryManager.AppUserRepository.GetByIdAsync(id, cancellationToken);

            if (appUser is null)
            {
                throw new AppUserNotFoundException(id);
            }

            var appUserResponse = _mapper.Map<AppUserDto>(appUser);

            return appUserResponse;
        }

        public async Task<AppUserDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var appUser = await _repositoryManager.AppUserRepository.GetByIdAsync(id, cancellationToken);

            if (appUser is null)
            {
                throw new AppUserNotFoundException(id);
            }

            var appUserResponse = _mapper.Map<AppUserDto>(appUser);

            return appUserResponse;
        }

        public async Task<AppUserDto> CreateAsync(AppUserDto appUserDto, CancellationToken cancellationToken = default)
        {
            var appUser = _mapper.Map<AppUser>(appUserDto);

            _repositoryManager.AppUserRepository.Insert(appUser);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AppUserDto>(appUser);
        }

        public async Task UpdateAsync(string id, AppUserDto appUserDto, CancellationToken cancellationToken = default)
        {
            var appUser = await _repositoryManager.AppUserRepository.GetByIdAsync(id, cancellationToken);

            if (appUser is null)
            {
                throw new AppUserNotFoundException(id);
            }

            _mapper.Map(appUserDto, appUser);

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