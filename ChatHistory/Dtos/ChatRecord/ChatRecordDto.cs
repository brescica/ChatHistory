using ChatHistory.API.Dtos.User;
using ChatHistory.Domain.Enums;

namespace ChatHistory.API.Dtos.ChatRecord
{
    public class ChatRecordDto : BaseDto
    {
        public ChatEventType ChatEventType { get; set; }
        public string? Comment { get; set; }
        public DateTime Time { get; set; }
        public UserDto Sender { get; set; }
        public UserDto? Receiver { get; set; }
    }
}
