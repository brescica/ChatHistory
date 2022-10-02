using System.ComponentModel;

namespace ChatHistory.Domain.Enums
{
    public enum AggregationLevel
    {
        [Description("Minute")]
        Minute = 0,
        [Description("Hour")]
        Hour = 1,
        [Description("Day")]
        Day = 2,
        [Description("Week")]
        Week = 3,
        [Description("Month")]
        Month = 4
    }
}
