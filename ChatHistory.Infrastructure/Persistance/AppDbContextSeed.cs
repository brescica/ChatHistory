using ChatHistory.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace ChatHistory.Infrastructure.Persistance
{
    public class AppDbContextSeed
    {
        private readonly ILogger<AppDbContextSeed> _logger;
        private readonly AppDbContext _context;

        public AppDbContextSeed(ILogger<AppDbContextSeed> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task SeedAsync()
        {
            try
            {
                var user1 = new User
                {
                    Username = "Ante",
                };
                var user2 = new User
                {
                    Username = "Karla"
                };
                var enter1 = new ChatRecord
                {
                    Sender = user1,
                    ChatEventType = Domain.Enums.ChatEventType.EnterRoom,
                    Time = DateTime.Parse("2022-10-04T21:32:51.4663136Z")
                };
                var enter2 = new ChatRecord
                {
                    Sender = user2,
                    ChatEventType = Domain.Enums.ChatEventType.EnterRoom,
                    Time = DateTime.Parse("2022-10-04T21:33:51.4663136Z")
                };
                var highFive1to2 = new ChatRecord
                {
                    Sender = user1,
                    Receiver = user2,
                    ChatEventType = Domain.Enums.ChatEventType.HighFive,
                    Time = DateTime.Parse("2022-10-04T21:34:51.4663136Z")
                };
                var highFive1to2_2 = new ChatRecord
                {
                    Sender = user1,
                    Receiver = user2,
                    ChatEventType = Domain.Enums.ChatEventType.HighFive,
                    Time = DateTime.Parse("2022-10-04T21:35:51.4663136Z")
                };
                var message1 = new ChatRecord
                {
                    Sender = user1,
                    Receiver = user2,
                    Comment = "Hello",
                    ChatEventType = Domain.Enums.ChatEventType.Comment,
                    Time = DateTime.Parse("2022-10-04T21:36:51.4663136Z")
                };
                var message2 = new ChatRecord
                {
                    Sender = user1,
                    Receiver = user2,
                    Comment = "Hello again",
                    ChatEventType = Domain.Enums.ChatEventType.Comment,
                    Time = DateTime.Parse("2022-10-04T21:36:52.4663136Z")
                };
                var highFive2to1 = new ChatRecord
                {
                    Sender = user2,
                    Receiver = user1,
                    ChatEventType = Domain.Enums.ChatEventType.HighFive,
                    Time = DateTime.Parse("2022-10-04T21:37:51.4663136Z")
                };
                var message3 = new ChatRecord
                {
                    Sender = user2,
                    Receiver = user1,
                    Comment = "Hello again",
                    ChatEventType = Domain.Enums.ChatEventType.Comment,
                    Time = DateTime.Parse("2022-10-04T21:37:55.4663136Z")
                };
                var leave2 = new ChatRecord
                {
                    Sender = user2,
                    ChatEventType = Domain.Enums.ChatEventType.LeaveRoom,
                    Time = DateTime.Parse("2022-10-04T21:38:51.4663136Z")
                };
                var leave1 = new ChatRecord
                {
                    Sender = user1,
                    ChatEventType = Domain.Enums.ChatEventType.LeaveRoom,
                    Time = DateTime.Parse("2022-10-04T21:39:51.4663136Z")
                };
                // seed users
                if (!_context.Users.Any())
                {
                    _context.Users.AddRange(user1, user2);

                    await _context.SaveChangesAsync();
                }

                // seed chat records
                if (!_context.ChatRecords.Any())
                {
                    _context.ChatRecords.AddRange(
                        enter1, enter2, highFive1to2, highFive1to2_2, message1, message2, highFive2to1, message3, leave2, leave1
                    );

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "An error has happened while seeding the initial data.");
                throw;
            }
        }
    }
}
