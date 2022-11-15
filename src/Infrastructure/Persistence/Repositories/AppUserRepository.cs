using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class AppUserRepository : IAppUserRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public AppUserRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<AppUser>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.AppUsers
                .Include(x => x.Items)
                .Include(x => x.Orders)
                .ToListAsync(cancellationToken);
        }
            

        public async Task<AppUser> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.AppUsers
                .Include(x => x.Items)
                .Include(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Insert(AppUser appUser) => _dbContext.AppUsers.Add(appUser);

        public void Remove(AppUser appUser) => _dbContext.AppUsers.Remove(appUser);
    }
}
