using ChatHistory.Application.Common.Helpers;
using ChatHistory.Domain.Enums;

namespace ChatHistory.Tests.Domain.UnitTests
{
    public class DateTimeFormaterTests
    {
        private const string testDateTimeValue = "2022-10-04T21:32:51.4663136Z";

        [Theory]
        [InlineData(testDateTimeValue, AggregationLevel.Month, "2022 October")]
        [InlineData(testDateTimeValue, AggregationLevel.Day, "2022 October 04")]
        [InlineData(testDateTimeValue, AggregationLevel.Hour, "2022 October 04, 11 PM")]
        [InlineData(testDateTimeValue, AggregationLevel.Minute, "2022 October 04, 11:32 PM")]
        public void FormatDateTimeToStringTest(string testValue, AggregationLevel aggregationLevel, string expected)
        {
            // Arrange            
            var testDateTimeValue = DateTime.Parse(testValue);

            // Act
            var result = DateTimeFormater.FormatDateTimeToString(testDateTimeValue, aggregationLevel);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}