using MomentJs.Net.Converters;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class Calendar
    {
        public Calendar()
        {
            SameDay = SameDayDefaultValue;
            NextDay = NextDayDefaultValue;
            NextWeek = NextWeekDefaultValue;
            LastDay = LastDayDefaultValue;
            LastWeek = LastWeekDefaultValue;
            SameElse = SameElseDefaultValue;
        }

        [JsonProperty("sameDay", Order = 1)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> SameDay { get; set; }

        public static LocaleDefinition.ValueResolver<string> SameDayDefaultValue => culture => null;

        [JsonProperty("nextDay", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> NextDay { get; set; }

        public static LocaleDefinition.ValueResolver<string> NextDayDefaultValue => culture => null;

        [JsonProperty("nextWeek", Order = 3)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> NextWeek { get; set; }

        public static LocaleDefinition.ValueResolver<string> NextWeekDefaultValue => culture => null;

        [JsonProperty("lastDay", Order = 4)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LastDay { get; set; }

        public static LocaleDefinition.ValueResolver<string> LastDayDefaultValue => culture => null;

        [JsonProperty("lastWeek", Order = 5)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LastWeek { get; set; }

        public static LocaleDefinition.ValueResolver<string> LastWeekDefaultValue => culture => null;

        [JsonProperty("sameElse", Order = 6)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> SameElse { get; set; }

        public static LocaleDefinition.ValueResolver<string> SameElseDefaultValue => culture => null;
    }
}