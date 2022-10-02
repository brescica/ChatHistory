using ChatHistory.Application.Persistance;
using ChatHistory.Domain.Entities;
using ChatHistory.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatHistory.Application.ChatHistory.Queries
{
    /// <summary>
    /// Query class for sending chat records search criteria
    /// </summary>
    public record GetChatHistoryQuery : IRequest<IEnumerable<ChatRecord>>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        //public ChatEventType ChatEventType { get; set; }
    }

    /// <summary>
    /// Mediator handler for GetDistanceQuery
    /// </summary>
    public class GetChatHistoryQueryHandler : IRequestHandler<GetChatHistoryQuery, IEnumerable<ChatRecord>>
    {
        private readonly ILogger<GetChatHistoryQueryHandler> _logger;
        private readonly IAppDbContext _context;

        public GetChatHistoryQueryHandler(ILogger<GetChatHistoryQueryHandler> logger, IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<ChatRecord>> Handle(GetChatHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var chatHistory = await _context.ChatRecords.Include(cr => cr.Sender).Include(cr => cr.Receiver).AsNoTracking().OrderBy(cr => cr.Id).ToListAsync();

                return chatHistory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "GetChatHistoryQueryHandler error occured");
                return null;
            }
        }
    }
}
