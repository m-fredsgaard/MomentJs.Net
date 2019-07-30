using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using MomentJs.Net.Converters;
using MomentJs.Net.Extensions;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class LocaleDefinition
    {
        public delegate T ValueResolver<out T>(CultureInfo culture);

        public LocaleDefinition()
        {
            Months = MonthsDefaultValue;
            MonthsShort = MonthsShortDefaultValue;
            MonthsParseExact = MonthsParseExactDefaultValue;
            Weekdays = WeekdaysDefaultValue;
            WeekdaysShort = WeekdaysShortDefaultValue;
            WeekdaysMin = WeekdaysMinDefaultValue;
            WeekdaysParseExact = WeekdaysParseExactDefaultValue;
            LongDateFormat = new LongDateFormat();
            Calendar = new Calendar();
            RelativeTime = new RelativeTime();
            DayOfMonthOrdinalParse = DayOfMonthOrdinalParseDefaultValue;
            Ordinal = OrdinalDefaultValue;
            Week = new Week();
        }

        [JsonProperty("months", Order = 1)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> Months { get; set; }

        public static ValueResolver<string[]> MonthsDefaultValue => culture =>
            culture.DateTimeFormat.MonthNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();

        [JsonProperty("monthsShort", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> MonthsShort { get; set; }

        public static ValueResolver<string[]> MonthsShortDefaultValue => culture =>
            culture.DateTimeFormat.AbbreviatedMonthNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();

        [JsonProperty("monthsParseExact", Order = 3)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<bool> MonthsParseExact { get; set; }

        public static ValueResolver<bool> MonthsParseExactDefaultValue => culture => true;

        [JsonProperty("weekdays", Order = 4)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> Weekdays { get; set; }

        public static ValueResolver<string[]> WeekdaysDefaultValue => culture =>
            culture.DateTimeFormat.DayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();

        [JsonProperty("weekdaysShort", Order = 5)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> WeekdaysShort { get; set; }

        public static ValueResolver<string[]> WeekdaysShortDefaultValue => culture =>
            culture.DateTimeFormat.AbbreviatedDayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();

        [JsonProperty("weekdaysMin", Order = 6)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> WeekdaysMin { get; set; }

        public static ValueResolver<string[]> WeekdaysMinDefaultValue => culture =>
            culture.DateTimeFormat.ShortestDayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();

        [JsonProperty("weekdaysParseExact", Order = 7)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<bool> WeekdaysParseExact { get; set; }

        public static ValueResolver<bool> WeekdaysParseExactDefaultValue => culture => true;

        [JsonProperty("longDateFormat", Order = 8)]
        public LongDateFormat LongDateFormat { get; set; }

        [JsonProperty("calendar", Order = 9)] public Calendar Calendar { get; set; }

        [JsonProperty("relativeTime", Order = 10)]
        public RelativeTime RelativeTime { get; set; }

        [JsonProperty("dayOfMonthOrdinalParse", Order = 11)]
        [JsonConverter(typeof(LocaleResolverJsonConverter<DayOfMonthOrdinalParseJsonConverter>))]
        public ValueResolver<Regex> DayOfMonthOrdinalParse { get; set; }

        public static ValueResolver<Regex> DayOfMonthOrdinalParseDefaultValue => culture => new Regex("\\d{1,2}");

        [JsonProperty("ordinal", Order = 12)]
        [JsonConverter(typeof(LocaleResolverJsonConverter<OrdinalJsonConverter>))]
        public ValueResolver<Ordinal> Ordinal { get; set; }

        public static ValueResolver<Ordinal> OrdinalDefaultValue => culture => "function (number) { return number; }";

        [JsonProperty("week", Order = 13)] public Week Week { get; set; }
    }
}