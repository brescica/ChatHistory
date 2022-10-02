using System.ComponentModel;

namespace ChatHistory.Domain.Enums
{
    public enum  ChatEventType
    {
        [Description("EnterRoom")]
        EnterRoom = 0,
        [Description("LeaveRoom")]
        LeaveRoom = 1,
        [Description("Comment")]
        Comment = 2,
        [Description("HighFive")]
        HighFive = 3
    }
}
