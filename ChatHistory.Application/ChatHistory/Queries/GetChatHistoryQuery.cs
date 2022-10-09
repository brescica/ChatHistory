using ChatHistory.Application.Persistance.Interfaces;
using ChatHistory.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatHistory.Application.ChatHistory.Queries
{
    /// <summary>
    /// Query class for sending chat records search criteria
    /// </summary>
    public record GetChatHistoryQuery : IRequest<IEnumerable<ChatRecord>>
    {
        public int Page { get; set; } = 1;
        public int Take { get; set; } = 10;

    }

    /// <summary>
    /// Mediator handler for GetChatHistoryQuery
    /// </summary>
    public class GetChatHistoryQueryHandler : IRequestHandler<GetChatHistoryQuery, IEnumerable<ChatRecord>>
    {
        private readonly ILogger<GetChatHistoryQueryHandler> _logger;
        private readonly IChatHistoryProvider _chatHistoryProvider;

        public GetChatHistoryQueryHandler(ILogger<GetChatHistoryQueryHandler> logger, IChatHistoryProvider chatHistoryProvider)
        {
            _logger = logger;
            _chatHistoryProvider = chatHistoryProvider;
        }

        public async Task<IEnumerable<ChatRecord>> Handle(GetChatHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _chatHistoryProvider.GetPaginatedChatRecords(request.Page, request.Take);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "GetChatHistoryQueryHandler error occured");
                return null;
            }
        }
    }
}
