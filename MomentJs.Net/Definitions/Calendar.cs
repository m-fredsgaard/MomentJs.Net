using System;
using System.Globalization;
using MomentJs.Net.Converters;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class Calendar
    {
        public Calendar()
        {
            SameDay = culture => GetDefaultValue<string>(nameof(SameDay), culture);
            NextDay = culture => GetDefaultValue<string>(nameof(NextDay), culture);
            NextWeek = culture => GetDefaultValue<string>(nameof(NextWeek), culture);
            LastDay = culture => GetDefaultValue<string>(nameof(LastDay), culture);
            LastWeek = culture => GetDefaultValue<string>(nameof(LastWeek), culture);
            SameElse = culture => GetDefaultValue<string>(nameof(SameElse), culture);
        }

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

        protected static T GetDefaultValue<T>(string type, CultureInfo culture)
        {
            object value;
            switch (type)
            {
                case nameof(SameDay):
                    value = "";
                    break;
                case nameof(NextDay):
                    value = "";
                    break;
                case nameof(NextWeek):
                    value = "";
                    break;
                case nameof(LastDay):
                    value = "";
                    break;
                case nameof(LastWeek):
                    value = "";
                    break;
                case nameof(SameElse):
                    value = "";
                    break;
                default:
                    value = default;
                    break;
            }

            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}