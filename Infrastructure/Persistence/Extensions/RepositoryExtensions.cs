using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Extensions
{
    public static class RepositoryExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IOwnerRepositoryAsync, OwnerRepository>();
            services.AddScoped<IAccountRepositoryAsync, AccountRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
