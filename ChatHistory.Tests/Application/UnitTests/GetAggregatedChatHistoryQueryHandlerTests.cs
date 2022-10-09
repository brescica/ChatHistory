using ChatHistory.Application.ChatHistory.Queries;
using ChatHistory.Application.Models;
using ChatHistory.Application.Persistance.Interfaces;
using ChatHistory.Domain.Entities;
using ChatHistory.Domain.Enums;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.Json;

namespace ChatHistory.Tests.Application.UnitTests
{
    public class GetAggregatedChatHistoryQueryHandlerTests
    {
        [Fact]
        public async Task GetMonthlyAggregatedChatHistoryQueryTests()
        {
            //Arange
            var expectedResultSerialized = @"{""2022 October"":[{""Count"":4,""ChatEventType"":0,""NumOfSenders"":2,""NumOfReceivers"":0},"+
                                        @"{""Count"":6,""ChatEventType"":3,""NumOfSenders"":2,""NumOfReceivers"":2},"+
                                        @"{""Count"":6,""ChatEventType"":2,""NumOfSenders"":2,""NumOfReceivers"":0},"+
                                        @"{""Count"":4,""ChatEventType"":1,""NumOfSenders"":2,""NumOfReceivers"":0}]}";
            var monthlyGroupedChatHistory = GetMonthyAggregatedChatRecords();

            var logger = new Mock<ILogger<GetAggregatedChatHistoryQueryHandler>>();
            var chatHistoryProvider = new Mock<IChatHistoryProvider>();
            GetAggregatedChatHistoryQuery query = new GetAggregatedChatHistoryQuery() { AggregationLevel = AggregationLevel.Month };
            GetAggregatedChatHistoryQueryHandler handler = new GetAggregatedChatHistoryQueryHandler(logger.Object, chatHistoryProvider.Object);

            // mock provider method
            chatHistoryProvider.Setup(ch => ch.GetMonthAggregatedChatHistory()).Returns(() => Task.FromResult(monthlyGroupedChatHistory));

            //Act
            var actualResponse = await handler.Handle(query, new CancellationToken());

            //Asert
            var actualResponseSerialized = JsonSerializer.Serialize(actualResponse);
            Assert.Equal(expectedResultSerialized, actualResponseSerialized);
        }

        #region Helpers and seed data
        private List<GroupedChatHistory> GetMonthyAggregatedChatRecords()
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
        #endregion
    }
}
