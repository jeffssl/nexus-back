using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexus.Infrastructure.Persistence;
using Nexus.Infrastructure.Persistence.Interceptors;

namespace Nexus.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntityInterceptor>();

        services.AddDbContext<NexusDbContext>((sp, options) =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            options.UseNpgsql(connectionString, builder =>
            {
                builder.MigrationsAssembly(typeof(NexusDbContext).Assembly.FullName);
            });
            
            // Apply snake_case naming convention for all tables/columns
            options.UseSnakeCaseNamingConvention();
        });

        // Bind the interface for the Application layer
        services.AddScoped<Nexus.Application.Common.Interfaces.INexusDbContext>(provider => provider.GetRequiredService<NexusDbContext>());

        return services;
    }
}
