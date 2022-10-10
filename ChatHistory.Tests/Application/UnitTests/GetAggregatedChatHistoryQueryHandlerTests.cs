using ChatHistory.Application.ChatHistory.Queries;
using ChatHistory.Application.Persistance.Interfaces;
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
            var expectedResultSerialized = ApplicationTestFixture.ExpectedMonthlyAggregatedSerialized;
            var monthlyGroupedChatHistory = ApplicationTestFixture.GetMonthyAggregatedChatRecords();

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
    }
}
