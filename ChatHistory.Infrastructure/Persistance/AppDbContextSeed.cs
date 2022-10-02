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
                    Username = "Ante"
                };
                var user2 = new User
                {
                    Username = "Karla"
                };
                var enter1 = new ChatRecord
                {
                    Sender = user1,
                    ChatEventType = Domain.Enums.ChatEventType.EnterRoom
                };
                var enter2 = new ChatRecord
                {
                    Sender = user2,
                    ChatEventType = Domain.Enums.ChatEventType.EnterRoom
                };
                var highFive1to2 = new ChatRecord
                {
                    Sender = user1,
                    Receiver = user2,
                    ChatEventType = Domain.Enums.ChatEventType.HighFive
                };
                var message1 = new ChatRecord
                {
                    Sender = user1,
                    Receiver = user2,
                    Comment = "Hi",
                    ChatEventType = Domain.Enums.ChatEventType.Comment
                };
                var leave1 = new ChatRecord
                {
                    Sender = user1,
                    ChatEventType = Domain.Enums.ChatEventType.LeaveRoom
                };
                var leave2 = new ChatRecord
                {
                    Sender = user2,
                    ChatEventType = Domain.Enums.ChatEventType.LeaveRoom
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
                        enter1, enter2, highFive1to2, message1, leave2, leave1
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
