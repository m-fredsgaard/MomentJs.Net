using MomentJs.Net.Converters;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class RelativeTime
    {
        [JsonProperty("future", Order = 1)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Future { get; set; }

        [JsonProperty("past", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Past { get; set; }

        [JsonProperty("s", Order = 3)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Second { get; set; }

        [JsonProperty("ss", Order = 4)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Seconds { get; set; }

        [JsonProperty("m", Order = 5)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Minute { get; set; }

        [JsonProperty("mm", Order = 6)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Minutes { get; set; }

        [JsonProperty("h", Order = 7)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Hour { get; set; }

        [JsonProperty("hh", Order = 8)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Hours { get; set; }

        [JsonProperty("d", Order = 9)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Day { get; set; }

        [JsonProperty("dd", Order = 10)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Days { get; set; }

        [JsonProperty("M", Order = 11)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Month { get; set; }

        [JsonProperty("MM", Order = 12)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Months { get; set; }

        [JsonProperty("y", Order = 13)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Year { get; set; }

        [JsonProperty("yy", Order = 14)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> Years { get; set; }
    }
}