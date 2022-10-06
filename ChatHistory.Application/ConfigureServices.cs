using ChatHistory.Application.ChatHistory.Queries;
using ChatHistory.Application.Models;
using ChatHistory.Application.Persistance.Interfaces;
using ChatHistory.Application.Persistance.Providers;
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
            services.AddScoped<IRequestHandler<GetAggregatedChatHistoryQuery, Dictionary<string, List<AggregatedChatResult>>>, GetAggregatedChatHistoryQueryHandler>();

            services.AddScoped<IChatHistoryProvider, ChatHistoryProvider>();

            return services;
        }
    }
}
