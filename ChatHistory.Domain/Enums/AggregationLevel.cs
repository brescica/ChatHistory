using System.ComponentModel;

namespace ChatHistory.Domain.Enums
{
    public enum AggregationLevel
    {
        [Description("Month")]
        Month = 0,
        [Description("Day")]
        Day = 1,
        [Description("Hour")]
        Hour = 2,
        [Description("Minute")]
        Minute = 3
    }
}
