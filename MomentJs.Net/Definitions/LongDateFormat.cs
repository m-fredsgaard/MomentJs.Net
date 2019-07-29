using System;
using System.Globalization;
using MomentJs.Net.Converters;
using MomentJs.Net.Formats;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace MomentJs.Net.Definitions
{
    public class LongDateFormat
    {
        public LongDateFormat()
        {
            LT = culture => GetDefaultValue<string>(nameof(LT), culture);
            LTS = culture => GetDefaultValue<string>(nameof(LTS), culture);
            L = culture => GetDefaultValue<string>(nameof(L), culture);
            LL = culture => GetDefaultValue<string>(nameof(LL), culture);
            LLL = culture => GetDefaultValue<string>(nameof(LLL), culture);
            LLLL = culture => GetDefaultValue<string>(nameof(LLLL), culture);
            l = culture => GetDefaultValue<string>(nameof(l), culture);
            ll = culture => GetDefaultValue<string>(nameof(ll), culture);
            lll = culture => GetDefaultValue<string>(nameof(lll), culture);
            llll = culture => GetDefaultValue<string>(nameof(llll), culture);
        }

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

        protected static T GetDefaultValue<T>(string type, CultureInfo culture)
        {
            object value;
            switch (type)
            {
                case nameof(LT):
                    value = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortTimePattern, culture,
                        DateFormat.LT);
                    break;
                case nameof(LTS):
                    value = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongTimePattern, culture,
                        DateFormat.LTS);
                    break;
                case nameof(L):
                    value = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, culture,
                        DateFormat.L);
                    break;
                case nameof(LL):
                    value = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, culture,
                        DateFormat.LL);
                    break;
                case nameof(LLL):
                    value = PatternConverter.ConvertToMomentPattern(
                        culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, culture,
                        DateFormat.LLL);
                    break;
                case nameof(LLLL):
                    value = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, culture,
                        DateFormat.LLLL);
                    break;
                case nameof(l):
                    value = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, culture,
                        DateFormat.l);
                    break;
                case nameof(ll):
                    value = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, culture,
                        DateFormat.ll);
                    break;
                case nameof(lll):
                    value = PatternConverter.ConvertToMomentPattern(
                        culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, culture,
                        DateFormat.lll);
                    break;
                case nameof(llll):
                    value = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, culture,
                        DateFormat.llll);
                    break;
                default:
                    value = default;
                    break;
            }

            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}