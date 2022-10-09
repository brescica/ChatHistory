using ChatHistory.Application.ChatHistory.Queries;
using ChatHistory.Application.Persistance.Interfaces;
using ChatHistory.Domain.Entities;
using ChatHistory.Domain.Enums;
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
            IEnumerable<ChatRecord> chatHistories_page1_take5 = GetChatRecordsPage1Take5();

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

        #region Helpers and seed data
        private IEnumerable<ChatRecord> GetChatRecordsPage1Take5()
        {
            // users
            var user1 = new User
            {
                Username = "Ante",
            };
            var user2 = new User
            {
                Username = "Karla"
            };

            // chat records
            var enter1 = new ChatRecord
            {
                Sender = user1,
                ChatEventType = ChatEventType.EnterRoom,
                Time = DateTime.Parse("2022-10-04T21:32:51.4663136Z")
            };
            var enter2 = new ChatRecord
            {
                Sender = user2,
                ChatEventType = ChatEventType.EnterRoom,
                Time = DateTime.Parse("2022-10-04T21:33:51.4663136Z")
            };
            var highFive1to2 = new ChatRecord
            {
                Sender = user1,
                Receiver = user2,
                ChatEventType = ChatEventType.HighFive,
                Time = DateTime.Parse("2022-10-04T21:34:51.4663136Z")
            };
            var highFive1to2_2 = new ChatRecord
            {
                Sender = user1,
                Receiver = user2,
                ChatEventType = ChatEventType.HighFive,
                Time = DateTime.Parse("2022-10-04T21:35:51.4663136Z")
            };
            var message1 = new ChatRecord
            {
                Sender = user1,
                Comment = "Hello",
                ChatEventType = ChatEventType.Comment,
                Time = DateTime.Parse("2022-10-04T21:36:51.4663136Z")
            };
            return new List<ChatRecord>()
            {
                enter1, enter2, highFive1to2, highFive1to2_2, message1
            };
        }
        #endregion
    }
}
