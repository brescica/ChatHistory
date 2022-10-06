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
                #region seed batch 1
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
                    Comment = "Hello",
                    ChatEventType = Domain.Enums.ChatEventType.Comment,
                    Time = DateTime.Parse("2022-10-04T21:36:51.4663136Z")
                };
                var message2 = new ChatRecord
                {
                    Sender = user1,
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
                    Comment = "Hi",
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
                # endregion

                #region seed batch 2
                var enter1_2 = new ChatRecord
                {
                    Sender = user1,
                    ChatEventType = Domain.Enums.ChatEventType.EnterRoom,
                    Time = DateTime.Parse("2022-10-04T22:32:51.4663136Z")
                };
                var enter2_2 = new ChatRecord
                {
                    Sender = user2,
                    ChatEventType = Domain.Enums.ChatEventType.EnterRoom,
                    Time = DateTime.Parse("2022-10-04T22:32:51.4663136Z")
                };
                var highFive1to2_2_2 = new ChatRecord
                {
                    Sender = user1,
                    Receiver = user2,
                    ChatEventType = Domain.Enums.ChatEventType.HighFive,
                    Time = DateTime.Parse("2022-10-04T22:32:51.4763136Z")
                };
                var highFive1to2_3_2 = new ChatRecord
                {
                    Sender = user1,
                    Receiver = user2,
                    ChatEventType = Domain.Enums.ChatEventType.HighFive,
                    Time = DateTime.Parse("2022-10-04T22:33:51.4663136Z")
                };
                var message1_2 = new ChatRecord
                {
                    Sender = user1,
                    Comment = "Hello",
                    ChatEventType = Domain.Enums.ChatEventType.Comment,
                    Time = DateTime.Parse("2022-10-04T22:33:51.4663136Z")
                };
                var message2_2 = new ChatRecord
                {
                    Sender = user1,
                    Comment = "Hello again",
                    ChatEventType = Domain.Enums.ChatEventType.Comment,
                    Time = DateTime.Parse("2022-10-04T22:36:52.4663136Z")
                };
                var highFive2to1_2 = new ChatRecord
                {
                    Sender = user2,
                    Receiver = user1,
                    ChatEventType = Domain.Enums.ChatEventType.HighFive,
                    Time = DateTime.Parse("2022-10-04T22:37:51.4663136Z")
                };
                var message3_2 = new ChatRecord
                {
                    Sender = user2,
                    Comment = "Hi",
                    ChatEventType = Domain.Enums.ChatEventType.Comment,
                    Time = DateTime.Parse("2022-10-04T22:37:55.4663136Z")
                };
                var leave2_2 = new ChatRecord
                {
                    Sender = user2,
                    ChatEventType = Domain.Enums.ChatEventType.LeaveRoom,
                    Time = DateTime.Parse("2022-10-04T22:38:51.4663136Z")
                };
                var leave1_2 = new ChatRecord
                {
                    Sender = user1,
                    ChatEventType = Domain.Enums.ChatEventType.LeaveRoom,
                    Time = DateTime.Parse("2022-10-04T22:38:51.4863136Z")
                };
                # endregion

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
                    _context.ChatRecords.AddRange(
                        enter1_2, enter2_2, highFive1to2_2_2, highFive2to1_2, message1_2, message2_2, highFive1to2_3_2, message3_2, leave2_2, leave1_2
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
