using Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        public IOwnerService OwnerService { get; }
        public IAccountService AccountService { get; }

        public ServiceManager(IOwnerService ownerService, IAccountService accountService)
        {
            OwnerService = ownerService;
            AccountService = accountService;
        }
    }
}
