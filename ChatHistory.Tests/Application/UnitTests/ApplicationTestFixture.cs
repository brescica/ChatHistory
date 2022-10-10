using ChatHistory.Application.Models;
using ChatHistory.Domain.Entities;
using ChatHistory.Domain.Enums;

namespace ChatHistory.Tests.Application.UnitTests
{
    public static class ApplicationTestFixture
    {
        public const string? ExpectedMonthlyAggregatedSerialized = @"{""2022 October"":[{""Count"":4,""ChatEventType"":0,""NumOfSenders"":2,""NumOfReceivers"":0}," +
                                        @"{""Count"":6,""ChatEventType"":3,""NumOfSenders"":2,""NumOfReceivers"":2}," +
                                        @"{""Count"":6,""ChatEventType"":2,""NumOfSenders"":2,""NumOfReceivers"":0}," +
                                        @"{""Count"":4,""ChatEventType"":1,""NumOfSenders"":2,""NumOfReceivers"":0}]}";
        public static List<ChatRecord> GetChatRecordsPage1Take5()
        {
            // users
            var user1 = new User()
            {
                Username = "Ante",
            };
            var user2 = new User()
            {
                Username = "Karla"
            };

            return new List<ChatRecord>() 
            {
            new ChatRecord() { Sender = user1, ChatEventType = ChatEventType.EnterRoom, Time = DateTime.Parse("2022-10-04T21:32:51.4663136Z") },
            new ChatRecord() { Sender = user2, ChatEventType = ChatEventType.EnterRoom, Time = DateTime.Parse("2022-10-04T21:33:51.4663136Z") },
            new ChatRecord() { Sender = user1, Receiver = user2, ChatEventType = ChatEventType.HighFive, Time = DateTime.Parse("2022-10-04T21:34:51.4663136Z") },
            new ChatRecord() { Sender = user1, Receiver = user2, ChatEventType = ChatEventType.HighFive, Time = DateTime.Parse("2022-10-04T21:35:51.4663136Z") },
            new ChatRecord() { Sender = user1, Comment = "Hello", ChatEventType = ChatEventType.Comment, Time = DateTime.Parse("2022-10-04T21:36:51.4663136Z") }
            };
        }

        public static List<GroupedChatHistory> GetMonthyAggregatedChatRecords()
        {
            List<GroupedChatHistory> groupedChatHistory = new List<GroupedChatHistory>()
            {
                new GroupedChatHistory(){ Time = new DateTime(2022, 10, 1), ChatEventType = ChatEventType.EnterRoom, Count = 4, NumOfSenders = 2, NumOfReceivers = 0 },
                new GroupedChatHistory(){ Time = new DateTime(2022, 10, 1), ChatEventType = ChatEventType.HighFive, Count = 6, NumOfSenders = 2, NumOfReceivers = 2 },
                new GroupedChatHistory(){ Time = new DateTime(2022, 10, 1), ChatEventType = ChatEventType.Comment, Count = 6, NumOfSenders = 2, NumOfReceivers = 0 },
                new GroupedChatHistory(){ Time = new DateTime(2022, 10, 1), ChatEventType = ChatEventType.LeaveRoom, Count = 4, NumOfSenders = 2, NumOfReceivers = 0 }
            };
            return groupedChatHistory;
        }
    }
}
