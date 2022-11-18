using Contracts;
using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUsersDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<AppUserDto> GetDetailsByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<AppUserDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<AppUserDto> CreateAsync(AppUserDto appUser, CancellationToken cancellationToken = default);

        Task UpdateAsync(string id, AppUserDto appUser, CancellationToken cancellationToken = default);

        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
    }
}