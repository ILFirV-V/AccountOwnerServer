using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRepositoryWrapper
    {
        IOwnerRepositoryAsync Owner { get; }
        IAccountRepositoryAsync Account { get; }
        Task SaveAsync();
    }
}