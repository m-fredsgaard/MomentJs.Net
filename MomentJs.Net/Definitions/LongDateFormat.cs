using MomentJs.Net.Converters;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace MomentJs.Net.Definitions
{
    public class LongDateFormat
    {
        [JsonProperty("LT", Order = 1)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LT { get; set; }

        [JsonProperty("LTS", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LTS { get; set; }

        [JsonProperty("L", Order = 3)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> L { get; set; }

        [JsonProperty("LL", Order = 4)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LL { get; set; }

        [JsonProperty("LLL", Order = 5)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LLL { get; set; }

        [JsonProperty("LLLL", Order = 6)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LLLL { get; set; }

        [JsonIgnore] public LocaleDefinition.ValueResolver<string> l { get; set; }

        [JsonIgnore] public LocaleDefinition.ValueResolver<string> ll { get; set; }

        [JsonIgnore] public LocaleDefinition.ValueResolver<string> lll { get; set; }

        [JsonIgnore] public LocaleDefinition.ValueResolver<string> llll { get; set; }
    }
}