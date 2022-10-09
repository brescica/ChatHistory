namespace ChatHistory.Tests.IntegrationTests
{
    public class ChatHistoryIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        public ChatHistoryIntegrationTests(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async void GetAggregatedChatHistoryTest()
        {
            // Arrange
            var expected = @"{""2022 October"":[{""count"":4,""chatEventType"":""EnterRoom"",""numOfSenders"":2,""numOfReceivers"":0},"+
                            @"{""count"":6,""chatEventType"":""HighFive"",""numOfSenders"":2,""numOfReceivers"":2},"+
                            @"{""count"":6,""chatEventType"":""Comment"",""numOfSenders"":2,""numOfReceivers"":0},"+
                            @"{""count"":4,""chatEventType"":""LeaveRoom"",""numOfSenders"":2,""numOfReceivers"":0}]}";
            var uri = "/api/chathistory/aggregated?aggregationlevel=Month";

            // Act
            var result = await _client.GetAsync(uri, new CancellationToken());

            //Assert
            Assert.True(result.IsSuccessStatusCode);
            var responseString = await result.Content.ReadAsStringAsync();
            Assert.Equal(expected, responseString);
        }
    }
}
