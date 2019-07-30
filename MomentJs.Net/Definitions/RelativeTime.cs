using System;
using System.Globalization;
using MomentJs.Net.Converters;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class RelativeTime
    {
        public RelativeTime()
        {
            Future = culture => GetDefaultValue<string>(nameof(Future), culture);
            Past = culture => GetDefaultValue<string>(nameof(Past), culture);
            Second = culture => GetDefaultValue<string>(nameof(Second), culture);
            Seconds = culture => GetDefaultValue<string>(nameof(Seconds), culture);
            Minute = culture => GetDefaultValue<string>(nameof(Minute), culture);
            Minutes = culture => GetDefaultValue<string>(nameof(Minutes), culture);
            Hour = culture => GetDefaultValue<string>(nameof(Hour), culture);
            Hours = culture => GetDefaultValue<string>(nameof(Hours), culture);
            Day = culture => GetDefaultValue<string>(nameof(Day), culture);
            Days = culture => GetDefaultValue<string>(nameof(Days), culture);
            Month = culture => GetDefaultValue<string>(nameof(Month), culture);
            Months = culture => GetDefaultValue<string>(nameof(Months), culture);
            Year = culture => GetDefaultValue<string>(nameof(Year), culture);
            Years = culture => GetDefaultValue<string>(nameof(Years), culture);
        }

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

        protected static T GetDefaultValue<T>(string type, CultureInfo culture)
        {
            object value;
            switch (type)
            {
                case nameof(Future):
                    value = "";
                    break;
                case nameof(Past):
                    value = "";
                    break;
                case nameof(Second):
                    value = "";
                    break;
                case nameof(Seconds):
                    value = "";
                    break;
                case nameof(Minute):
                    value = "";
                    break;
                case nameof(Minutes):
                    value = "";
                    break;
                case nameof(Hour):
                    value = "";
                    break;
                case nameof(Hours):
                    value = "";
                    break;
                case nameof(Day):
                    value = "";
                    break;
                case nameof(Days):
                    value = "";
                    break;
                case nameof(Month):
                    value = "";
                    break;
                case nameof(Months):
                    value = "";
                    break;
                case nameof(Year):
                    value = "";
                    break;
                case nameof(Years):
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