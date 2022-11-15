using Contracts;
using DataTransfertObjects;

namespace Services.Abstractions
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUsersReadDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<AppUserReadDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<AppUserReadDto> CreateAsync(AppUserWriteDto appUser, CancellationToken cancellationToken = default);

        Task UpdateAsync(string id, AppUserWriteDto appUser, CancellationToken cancellationToken = default);

        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
    }
}