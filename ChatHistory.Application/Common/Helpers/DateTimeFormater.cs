using ChatHistory.Domain.Enums;

namespace ChatHistory.Application.Common.Helpers
{
    public static class DateTimeFormater
    {
        public static string FormatDateTimeToString(DateTime dateTime, AggregationLevel aggregationLevel)
        {
            return aggregationLevel switch
            {
                AggregationLevel.Month => dateTime.ToString("yyyy MMMM"),
                AggregationLevel.Day => dateTime.ToString("yyyy MMMM dd"),
                AggregationLevel.Hour => dateTime.ToString("yyyy MMMM dd, h tt"),
                AggregationLevel.Minute => dateTime.ToString("yyyy MMMM dd, h:mm tt"),
                _ => "Unknown Aggregation Level"
            };
        }
    }
}
