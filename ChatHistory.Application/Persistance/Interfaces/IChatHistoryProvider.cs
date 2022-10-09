using ChatHistory.Application.Models;
using ChatHistory.Domain.Entities;

namespace ChatHistory.Application.Persistance.Interfaces
{
    public interface IChatHistoryProvider
    {
        Task<IEnumerable<ChatRecord>> GetPaginatedChatRecords(int page, int take);
        Task<List<GroupedChatHistory>> GetMonthAggregatedChatHistory();
        Task<List<GroupedChatHistory>> GetDayAggregatedChatHistory();
        Task<List<GroupedChatHistory>> GetHourAggregatedChatHistory();
        Task<List<GroupedChatHistory>> GetMinuteAggregatedChatHistory();
    }
}
