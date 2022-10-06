using ChatHistory.Application.Models;

namespace ChatHistory.Application.Persistance.Interfaces
{
    public interface IChatHistoryProvider
    {
        Task<List<GroupedChatHistory>> GetMonthAggregatedChatHistory();
        Task<List<GroupedChatHistory>> GetDayAggregatedChatHistory();
        Task<List<GroupedChatHistory>> GetHourAggregatedChatHistory();
        Task<List<GroupedChatHistory>> GetMinuteAggregatedChatHistory();
    }
}
