using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repository
{
    public interface IAccountRepositoryAsync : IRepositoryBase<Account>
    {
        Task<IEnumerable<Account>> AccountsByOwnerAsync(Guid ownerId);
    }
}