using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Repository
{
    public interface IAccountRepositoryAsync : IRepositoryBase<AccountDbModel>
    {
        Task<IEnumerable<AccountDbModel>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
        Task<AccountDbModel?> GetAccountByOwner(Guid ownerId, Guid id, CancellationToken cancellationToken = default);
    }
}