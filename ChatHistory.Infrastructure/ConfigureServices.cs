using ChatHistory.Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ChatHistory.Application.Persistance.Interfaces;

namespace ChatHistory.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (Boolean.TryParse(configuration.GetSection("UseInMemoryDatabase").Value, out bool result) && result)
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("ChatHistoryDb"));
            }

            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
            services.AddScoped<AppDbContextSeed>();

            return services;
        }
    }
}
