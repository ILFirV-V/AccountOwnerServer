using Domain.DbModels;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Helpers;
using Persistence.Helpers.interfaces;
using Persistence.Repository;
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
            services.AddScoped<ISortHelper<OwnerDbModel>, SortHelper<OwnerDbModel>>();
            services.AddScoped<ISortHelper<AccountDbModel>, SortHelper<AccountDbModel>>();
            services.AddScoped<IOwnerRepositoryAsync, OwnerRepository>();
            services.AddScoped<IAccountRepositoryAsync, AccountRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
