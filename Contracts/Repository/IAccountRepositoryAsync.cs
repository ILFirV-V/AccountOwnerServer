using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DbModels;

namespace Contracts.Repository
{
    public interface IAccountRepositoryAsync : IRepositoryBase<AccountDbModel>
    {
        Task<IEnumerable<AccountDbModel>> GetAccountsByOwner(Guid ownerId);
        Task<AccountDbModel?> GetAccountByOwner(Guid ownerId, Guid id);
    }
}