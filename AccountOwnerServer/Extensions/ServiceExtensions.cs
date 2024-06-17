
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace AccountOwnerServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigurePostgresqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["PostgresqlConnection:connectionString"];

            services.AddDbContext<RepositoryContext>(o => o.UseNpgsql(connectionString));
        }
    }
}
