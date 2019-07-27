using MomentJs.Net.Converters;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class Calendar
    {
        [JsonProperty("sameDay", Order = 1)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> SameDay { get; set; }

        [JsonProperty("nextDay", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> NextDay { get; set; }

        [JsonProperty("nextWeek", Order = 3)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> NextWeek { get; set; }

        [JsonProperty("lastDay", Order = 4)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LastDay { get; set; }

        [JsonProperty("lastWeek", Order = 5)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LastWeek { get; set; }

        [JsonProperty("sameElse", Order = 6)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> SameElse { get; set; }
    }
}