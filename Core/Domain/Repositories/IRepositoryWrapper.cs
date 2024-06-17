using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepositoryWrapper
    {
        public IOwnerRepositoryAsync Owner { get; }
        public IAccountRepositoryAsync Account { get; }
        public Task SaveAsync(CancellationToken cancellationToken = default);
    }
}