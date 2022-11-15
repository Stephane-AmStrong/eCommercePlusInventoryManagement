using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAppUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<AppUser> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        void Insert(AppUser appUser);
        void Remove(AppUser appUser);
    }
}
