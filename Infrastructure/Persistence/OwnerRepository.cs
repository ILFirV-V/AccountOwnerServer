using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DbModels;
using Domain.Models.Parameters;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    internal sealed class OwnerRepository : RepositoryBase<OwnerDbModel>, IOwnerRepositoryAsync
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<OwnerDbModel>> GetAllOwnersAsync(OwnerParameters ownerParameters, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(o => o.DateOfBirth >= ownerParameters.MinDateOfBirth &&
                                o.DateOfBirth <= ownerParameters.MaxDateOfBirth)
                .OrderBy(ow => ow.Name)
                .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .ToListAsync(cancellationToken);
        }

        public Task<OwnerDbModel?> GetOwnerByIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<OwnerDbModel?> GetOwnerWithDetailsAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}