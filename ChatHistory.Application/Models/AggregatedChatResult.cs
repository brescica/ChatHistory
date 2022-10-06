using ChatHistory.Domain.Enums;

namespace ChatHistory.Application.Models
{
    public class AggregatedChatResult
    {
        public int Count { get; set; }
        public ChatEventType ChatEventType { get; set; }
        public int NumOfSenders { get; set; }
        public int NumOfReceivers { get; set; }

        public AggregatedChatResult(int count, ChatEventType type, int numOfSenders, int numOfReceivers)
        {
            Count = count;
            ChatEventType = type;
            NumOfSenders = numOfSenders;
            NumOfReceivers = numOfReceivers;
        }
    }
}
