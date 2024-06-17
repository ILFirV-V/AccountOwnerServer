using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;
using Services.Mapper;

namespace Services.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
