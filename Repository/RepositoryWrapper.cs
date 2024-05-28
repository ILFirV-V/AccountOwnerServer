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
        public IOwnerRepository Owner { get; }
        public IAccountRepository Account { get; }

        public RepositoryWrapper(RepositoryContext repositoryContext, IOwnerRepository ownerRepository, IAccountRepository accountRepository)
        {
            repoContext = repositoryContext;
            Owner = ownerRepository;
            Account = accountRepository;
        }

        public void Save()
        {
            repoContext.SaveChanges();
        }
    }
}