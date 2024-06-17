using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    internal sealed class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext repoContext;
        public IOwnerRepositoryAsync Owner { get; }
        public IAccountRepositoryAsync Account { get; }

        public RepositoryWrapper(RepositoryContext repositoryContext, IOwnerRepositoryAsync ownerRepository, IAccountRepositoryAsync accountRepository)
        {
            repoContext = repositoryContext;
            Owner = ownerRepository;
            Account = accountRepository;
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await repoContext.SaveChangesAsync();
        }
    }
}