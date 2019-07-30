using MomentJs.Net.Converters;
using MomentJs.Net.Formats;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class LongDateFormat
    {
        public LongDateFormat()
        {
            ShortTime = ShortTimeDefaultValue;
            LongTime = LongTimeDefaultValue;
            ShortDate = ShortDateDefaultValue;
            LongDate = LongDateDefaultValue;
            LongDateShortTime = LongDateShortTimeDefaultValue;
            FullDateTime = FullDateTimeDefaultValue;
            ShortDateCompact = ShortDateCompactDefaultValue;
            LongDateCompact = LongDateCompactDefaultValue;
            LongDateShortTimeCompact = LongDateShortTimeCompactDefaultValue;
            FullDateTimeCompact = FullDateTimeCompactDefaultValue;
        }

        [JsonProperty("LT", Order = 1)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> ShortTime { get; set; }

        public static LocaleDefinition.ValueResolver<string> ShortTimeDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortTimePattern, culture, DateFormat.LT);

        [JsonProperty("LTS", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LongTime { get; set; }

        public static LocaleDefinition.ValueResolver<string> LongTimeDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongTimePattern, culture, DateFormat.LTS);

        [JsonProperty("L", Order = 3)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> ShortDate { get; set; }

        public static LocaleDefinition.ValueResolver<string> ShortDateDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, culture, DateFormat.L);

        [JsonProperty("LL", Order = 4)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LongDate { get; set; }

        public static LocaleDefinition.ValueResolver<string> LongDateDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, culture, DateFormat.LL);

        [JsonProperty("LLL", Order = 5)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> LongDateShortTime { get; set; }

        public static LocaleDefinition.ValueResolver<string> LongDateShortTimeDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(
                culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, culture,
                DateFormat.LLL);

        [JsonProperty("LLLL", Order = 6)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<string> FullDateTime { get; set; }

        public static LocaleDefinition.ValueResolver<string> FullDateTimeDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, culture,
                DateFormat.LLLL);

        [JsonIgnore] public LocaleDefinition.ValueResolver<string> ShortDateCompact { get; set; }

        public static LocaleDefinition.ValueResolver<string> ShortDateCompactDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, culture, DateFormat.l);

        [JsonIgnore] public LocaleDefinition.ValueResolver<string> LongDateCompact { get; set; }

        public static LocaleDefinition.ValueResolver<string> LongDateCompactDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, culture, DateFormat.ll);

        [JsonIgnore] public LocaleDefinition.ValueResolver<string> LongDateShortTimeCompact { get; set; }

        public static LocaleDefinition.ValueResolver<string> LongDateShortTimeCompactDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(
                culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, culture,
                DateFormat.lll);

        [JsonIgnore] public LocaleDefinition.ValueResolver<string> FullDateTimeCompact { get; set; }

        public static LocaleDefinition.ValueResolver<string> FullDateTimeCompactDefaultValue => culture =>
            PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, culture,
                DateFormat.llll);
    }
}