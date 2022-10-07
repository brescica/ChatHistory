using ChatHistory.Application.Models;
using ChatHistory.Application.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatHistory.Infrastructure.Persistance.Providers
{
    public class ChatHistoryProvider : IChatHistoryProvider
    {
        private readonly IAppDbContext _context;

        public ChatHistoryProvider(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<GroupedChatHistory>> GetMonthAggregatedChatHistory()
        {
            return await _context.ChatRecords.AsNoTracking()
                        .GroupBy(cr => new { cr.Time.Year, cr.Time.Month, cr.ChatEventType })
                        .OrderBy(x => x.Key.Year).ThenBy(x => x.Key.Month)
                        .Select(r => new GroupedChatHistory
                        {
                            Time = new DateTime(r.Key.Year, r.Key.Month, 1),
                            ChatEventType = r.Key.ChatEventType,
                            Count = r.Count(),
                            NumOfSenders = r.ToList().Select(x => x.SenderId).Distinct().Count(),
                            NumOfReceivers = r.ToList().Where(x => x.ReceiverId != null).Select(x => x.ReceiverId).Distinct().Count()
                        })
                        .ToListAsync();
        }
        public async Task<List<GroupedChatHistory>> GetDayAggregatedChatHistory()
        {
            return await _context.ChatRecords.AsNoTracking()
                        .GroupBy(cr => new { cr.Time.Year, cr.Time.Month, cr.Time.Day, cr.ChatEventType })
                        .OrderBy(x => x.Key.Year).ThenBy(x => x.Key.Month).ThenBy(x => x.Key.Day)
                        .Select(r => new GroupedChatHistory
                        {
                            Time = new DateTime(r.Key.Year, r.Key.Month, r.Key.Day),
                            ChatEventType = r.Key.ChatEventType,
                            Count = r.Count(),
                            NumOfSenders = r.ToList().Select(x => x.SenderId).Distinct().Count(),
                            NumOfReceivers = r.ToList().Where(x => x.ReceiverId != null).Select(x => x.ReceiverId).Distinct().Count()
                        })
                        .ToListAsync();
        }

        public async Task<List<GroupedChatHistory>> GetHourAggregatedChatHistory()
        {
            return await _context.ChatRecords.AsNoTracking()
                        .GroupBy(cr => new { cr.Time.Year, cr.Time.Month, cr.Time.Day, cr.Time.Hour, cr.ChatEventType })
                        .OrderBy(x => x.Key.Year).ThenBy(x => x.Key.Month).ThenBy(x => x.Key.Day).ThenBy(x => x.Key.Hour)
                        .Select(r => new GroupedChatHistory
                        {
                            Time = new DateTime(r.Key.Year, r.Key.Month, r.Key.Day, r.Key.Hour, 0, 0),
                            ChatEventType = r.Key.ChatEventType,
                            Count = r.Count(),
                            NumOfSenders = r.ToList().Select(x => x.SenderId).Distinct().Count(),
                            NumOfReceivers = r.ToList().Where(x => x.ReceiverId != null).Select(x => x.ReceiverId).Distinct().Count()
                        })
                        .ToListAsync();
        }

        public async Task<List<GroupedChatHistory>> GetMinuteAggregatedChatHistory()
        {
            return await _context.ChatRecords.AsNoTracking()
                        .GroupBy(cr => new { cr.Time.Year, cr.Time.Month, cr.Time.Day, cr.Time.Hour, cr.Time.Minute, cr.ChatEventType })
                        .OrderBy(x => x.Key.Year).ThenBy(x => x.Key.Month).ThenBy(x => x.Key.Day).ThenBy(x => x.Key.Hour).ThenBy(x => x.Key.Minute)
                        .Select(r => new GroupedChatHistory
                        {
                            Time = new DateTime(r.Key.Year, r.Key.Month, r.Key.Day, r.Key.Hour, r.Key.Minute, 0),
                            ChatEventType = r.Key.ChatEventType,
                            Count = r.Count(),
                            NumOfSenders = r.ToList().Select(x => x.SenderId).Distinct().Count(),
                            NumOfReceivers = r.ToList().Where(x => x.ReceiverId != null).Select(x => x.ReceiverId).Distinct().Count()
                        })
                        .ToListAsync();
        }
    }
}
