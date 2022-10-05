using ChatHistory.Domain.Common;
using ChatHistory.Domain.Enums;

namespace ChatHistory.Domain.Entities
{
    public class ChatRecord : BaseEntity
    {
        public ChatEventType ChatEventType { get; set; }
        public string? Comment { get; set; }
        public DateTime Time { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int? ReceiverId { get; set; }
        public User? Receiver { get; set; }
    }
}
