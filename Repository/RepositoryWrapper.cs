using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;
using Entities;

namespace Repository
{
    public sealed class RepositoryWrapper : IRepositoryWrapper
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

        public async Task SaveAsync()
        {
            await repoContext.SaveChangesAsync();
        }
    }
}