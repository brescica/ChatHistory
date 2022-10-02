using ChatHistory.Domain.Common;

namespace ChatHistory.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public ICollection<ChatRecord> SentChatRecords { get; set; }
        public ICollection<ChatRecord> ReceivedChatRecords { get; set; }
    }
}
