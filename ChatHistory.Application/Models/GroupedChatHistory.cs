using ChatHistory.Domain.Enums;

namespace ChatHistory.Application.Models
{
    public class GroupedChatHistory
    {
        public DateTime Time { get; set; }
        public int Count { get; set; }
        public ChatEventType ChatEventType { get; set; }
        public int NumOfSenders { get; set; }
        public int NumOfReceivers { get; set; }
    }
}
