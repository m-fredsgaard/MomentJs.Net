using MomentJs.Net.Converters;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
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
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Future { get; set; }

        public static LocaleDefinition.ValueResolver<string> FutureDefaultValue => culture => null;

        [JsonProperty("past", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Past { get; set; }

        public static LocaleDefinition.ValueResolver<string> PastDefaultValue => culture => null;

        [JsonProperty("s", Order = 3)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Second { get; set; }

        public static LocaleDefinition.ValueResolver<string> SecondDefaultValue => culture => null;

        [JsonProperty("ss", Order = 4)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Seconds { get; set; }

        public static LocaleDefinition.ValueResolver<string> SecondsDefaultValue => culture => null;

        [JsonProperty("m", Order = 5)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Minute { get; set; }

        public static LocaleDefinition.ValueResolver<string> MinuteDefaultValue => culture => null;

        [JsonProperty("mm", Order = 6)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Minutes { get; set; }

        public static LocaleDefinition.ValueResolver<string> MinutesDefaultValue => culture => null;

        [JsonProperty("h", Order = 7)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Hour { get; set; }

        public static LocaleDefinition.ValueResolver<string> HourDefaultValue => culture => null;

        [JsonProperty("hh", Order = 8)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Hours { get; set; }

        public static LocaleDefinition.ValueResolver<string> HoursDefaultValue => culture => null;

        [JsonProperty("d", Order = 9)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Day { get; set; }

        public static LocaleDefinition.ValueResolver<string> DayDefaultValue => culture => null;

        [JsonProperty("dd", Order = 10)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Days { get; set; }

        public static LocaleDefinition.ValueResolver<string> DaysDefaultValue => culture => null;

        [JsonProperty("M", Order = 11)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Month { get; set; }

        public static LocaleDefinition.ValueResolver<string> MonthDefaultValue => culture => null;

        [JsonProperty("MM", Order = 12)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Months { get; set; }

        public static LocaleDefinition.ValueResolver<string> MonthsDefaultValue => culture => null;

        [JsonProperty("y", Order = 13)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Year { get; set; }

        public static LocaleDefinition.ValueResolver<string> YearDefaultValue => culture => null;

        [JsonProperty("yy", Order = 14)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Years { get; set; }

        public static LocaleDefinition.ValueResolver<string> YearsDefaultValue => culture => null;
    }
}