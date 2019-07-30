using MomentJs.Net.Converters;
using Newtonsoft.Json;

namespace MomentJs.Net.Globalization
{
    public class RelativeTime
    {
        public RelativeTime()
        {
            Future = FutureDefaultValue;
            Past = PastDefaultValue;
            Second = SecondDefaultValue;
            Seconds = SecondsDefaultValue;
            Minute = MinuteDefaultValue;
            Minutes = MinutesDefaultValue;
            Hour = HourDefaultValue;
            Hours = HoursDefaultValue;
            Day = DayDefaultValue;
            Days = DaysDefaultValue;
            Month = MonthDefaultValue;
            Months = MonthsDefaultValue;
            Year = YearDefaultValue;
            Years = YearsDefaultValue;
        }

        [JsonProperty("future", Order = 1)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Future { get; set; }

        public static ValueResolver<string> FutureDefaultValue => culture => null;

        [JsonProperty("past", Order = 2)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Past { get; set; }

        public static ValueResolver<string> PastDefaultValue => culture => null;

        [JsonProperty("s", Order = 3)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Second { get; set; }

        public static ValueResolver<string> SecondDefaultValue => culture => null;

        [JsonProperty("ss", Order = 4)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Seconds { get; set; }

        public static ValueResolver<string> SecondsDefaultValue => culture => null;

        [JsonProperty("m", Order = 5)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Minute { get; set; }

        public static ValueResolver<string> MinuteDefaultValue => culture => null;

        [JsonProperty("mm", Order = 6)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Minutes { get; set; }

        public static ValueResolver<string> MinutesDefaultValue => culture => null;

        [JsonProperty("h", Order = 7)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Hour { get; set; }

        public static ValueResolver<string> HourDefaultValue => culture => null;

        [JsonProperty("hh", Order = 8)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Hours { get; set; }

        public static ValueResolver<string> HoursDefaultValue => culture => null;

        [JsonProperty("d", Order = 9)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Day { get; set; }

        public static ValueResolver<string> DayDefaultValue => culture => null;

        [JsonProperty("dd", Order = 10)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Days { get; set; }

        public static ValueResolver<string> DaysDefaultValue => culture => null;

        [JsonProperty("M", Order = 11)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Month { get; set; }

        public static ValueResolver<string> MonthDefaultValue => culture => null;

        [JsonProperty("MM", Order = 12)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Months { get; set; }

        public static ValueResolver<string> MonthsDefaultValue => culture => null;

        [JsonProperty("y", Order = 13)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Year { get; set; }

        public static ValueResolver<string> YearDefaultValue => culture => null;

        [JsonProperty("yy", Order = 14)]
        [JsonConverter(typeof(ValueResolverJsonConverter))]
        public ValueResolver<string> Years { get; set; }

        public static ValueResolver<string> YearsDefaultValue => culture => null;
    }
}