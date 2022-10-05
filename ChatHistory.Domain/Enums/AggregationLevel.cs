using System.ComponentModel;

namespace ChatHistory.Domain.Enums
{
    public enum AggregationLevel
    {
        [Description("None")]
        None = 0,
        [Description("Minute")]
        Minute = 1,
        [Description("Hour")]
        Hour = 2,
        [Description("Day")]
        Day = 3,
        [Description("Week")]
        Week = 4,
        [Description("Month")]
        Month = 5
    }
}
