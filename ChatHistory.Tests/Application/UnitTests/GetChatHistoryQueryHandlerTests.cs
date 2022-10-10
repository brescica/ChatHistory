using ChatHistory.Application.ChatHistory.Queries;
using ChatHistory.Application.Persistance.Interfaces;
using ChatHistory.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace ChatHistory.Tests.Application.UnitTests
{
    public class GetChatHistoryQueryHandlerTests
    {
        [Fact]
        public async Task GetChatHistoryQueryTests()
        {
            //Arange
            IEnumerable<ChatRecord> chatHistories_page1_take5 = ApplicationTestFixture.GetChatRecordsPage1Take5();

            var logger = new Mock<ILogger<GetChatHistoryQueryHandler>>();
            var chatHistoryProvider = new Mock<IChatHistoryProvider>();
            GetChatHistoryQuery query = new GetChatHistoryQuery() { Page = 1, Take = 5 };
            GetChatHistoryQueryHandler handler = new GetChatHistoryQueryHandler(logger.Object, chatHistoryProvider.Object);

            // mock provider method
            chatHistoryProvider.Setup(ch => ch.GetPaginatedChatRecords(1, 5)).Returns(() => Task.FromResult(chatHistories_page1_take5));

            //Act
            var response = await handler.Handle(query, new CancellationToken());

            //Asert
            Assert.Equal(chatHistories_page1_take5, response);
        }
    }
}
