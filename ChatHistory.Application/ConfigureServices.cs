using ChatHistory.Application.ChatHistory.Queries;
using ChatHistory.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ChatHistory.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IRequestHandler<GetChatHistoryQuery, IEnumerable<ChatRecord>>, GetChatHistoryQueryHandler>();

            return services;
        }
    }
}
