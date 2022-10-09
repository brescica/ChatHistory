using ChatHistory.Application.Common.Helpers;
using ChatHistory.Application.Models;
using ChatHistory.Application.Persistance.Interfaces;
using ChatHistory.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatHistory.Application.ChatHistory.Queries
{
    /// <summary>
    /// Query class for sending aggregated chat records search criteria
    /// </summary>
    public record GetAggregatedChatHistoryQuery : IRequest<Dictionary<string, List<AggregatedChatResult>>>
    {
        public AggregationLevel AggregationLevel { get; set; } = AggregationLevel.Minute;

    }

    /// <summary>
    /// Mediator handler for GetAggregatedChatHistoryQuery
    /// </summary>
    public class GetAggregatedChatHistoryQueryHandler : IRequestHandler<GetAggregatedChatHistoryQuery, Dictionary<string, List<AggregatedChatResult>>>
    {
        private readonly ILogger<GetAggregatedChatHistoryQueryHandler> _logger;
        private readonly IChatHistoryProvider _chatHistoryProvider;

        public GetAggregatedChatHistoryQueryHandler(ILogger<GetAggregatedChatHistoryQueryHandler> logger, IChatHistoryProvider chatHistoryProvider)
        {
            _logger = logger;
            _chatHistoryProvider = chatHistoryProvider;
        }

        public async Task<Dictionary<string, List<AggregatedChatResult>>> Handle(GetAggregatedChatHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var groupedByDateTimeAndEventType = request.AggregationLevel switch
                {
                    AggregationLevel.Month => await _chatHistoryProvider.GetMonthAggregatedChatHistory(),
                    AggregationLevel.Day => await _chatHistoryProvider.GetDayAggregatedChatHistory(),
                    AggregationLevel.Hour => await _chatHistoryProvider.GetHourAggregatedChatHistory(),
                    AggregationLevel.Minute => await _chatHistoryProvider.GetMinuteAggregatedChatHistory(),
                    _ => null
                };

                Dictionary<string, List<AggregatedChatResult>> aggregatedResult = new Dictionary<string, List<AggregatedChatResult>>();

                foreach (GroupedChatHistory group in groupedByDateTimeAndEventType)
                {
                    var key = DateTimeFormater.FormatDateTimeToString(group.Time, request.AggregationLevel);

                    if (aggregatedResult.ContainsKey(key))
                    {
                        aggregatedResult[key].Add(new AggregatedChatResult(group.Count, group.ChatEventType, group.NumOfSenders, group.NumOfReceivers));
                    }
                    else
                    {
                        aggregatedResult.Add(key, new List<AggregatedChatResult>()
                        { new AggregatedChatResult(group.Count, group.ChatEventType, group.NumOfSenders, group.NumOfReceivers) });
                    }
                }

                return aggregatedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "GetAggregatedChatHistoryQueryHandler error occured");
                return new Dictionary<string, List<AggregatedChatResult>>();
            }
        }
    }
}
