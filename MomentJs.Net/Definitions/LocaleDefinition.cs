using System;
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
            Months = culture => GetDefaultValue<string[]>(nameof(Months), culture);
            MonthsShort = culture => GetDefaultValue<string[]>(nameof(MonthsShort), culture);
            MonthsParseExact = culture => GetDefaultValue<bool>(nameof(MonthsParseExact), culture);
            Weekdays = culture => GetDefaultValue<string[]>(nameof(Weekdays), culture);
            WeekdaysShort = culture => GetDefaultValue<string[]>(nameof(WeekdaysShort), culture);
            WeekdaysMin = culture => GetDefaultValue<string[]>(nameof(WeekdaysMin), culture);
            WeekdaysParseExact = culture => GetDefaultValue<bool>(nameof(MonthsParseExact), culture);
            LongDateFormat = new LongDateFormat();
            Calendar = new Calendar();
            RelativeTime = new RelativeTime();
            DayOfMonthOrdinalParse = culture => GetDefaultValue<Regex>(nameof(DayOfMonthOrdinalParse), culture);
            Ordinal = culture => GetDefaultValue<string>(nameof(Ordinal), culture);
            Week = new Week();
        }

        [JsonProperty("months", Order = 1)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> Months { get; set; }

        [JsonProperty("monthsShort", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> MonthsShort { get; set; }

        [JsonProperty("monthsParseExact", Order = 3)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<bool> MonthsParseExact { get; set; }

        [JsonProperty("weekdays", Order = 4)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> Weekdays { get; set; }

        [JsonProperty("weekdaysShort", Order = 5)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> WeekdaysShort { get; set; }

        [JsonProperty("weekdaysMin", Order = 6)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<string[]> WeekdaysMin { get; set; }

        [JsonProperty("weekdaysParseExact", Order = 7)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public ValueResolver<bool> WeekdaysParseExact { get; set; }

        [JsonProperty("longDateFormat", Order = 8)]
        public LongDateFormat LongDateFormat { get; set; }

        [JsonProperty("calendar", Order = 9)] public Calendar Calendar { get; set; }

        [JsonProperty("relativeTime", Order = 10)]
        public RelativeTime RelativeTime { get; set; }

        [JsonProperty("dayOfMonthOrdinalParse", Order = 11)]
        [JsonConverter(typeof(LocaleResolverJsonConverter<DayOfMonthOrdinalParseJsonConverter>))]
        public ValueResolver<Regex> DayOfMonthOrdinalParse { get; set; }

        [JsonProperty("ordinal", Order = 12)]
        [JsonConverter(typeof(LocaleResolverJsonConverter<OrdinalJsonConverter>))]
        public ValueResolver<Ordinal> Ordinal { get; set; }

        [JsonProperty("week", Order = 13)] public Week Week { get; set; }

        protected static T GetDefaultValue<T>(string type, CultureInfo culture)
        {
            object value;
            switch (type)
            {
                case nameof(Months):
                    value = culture.DateTimeFormat.MonthNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
                    break;
                case nameof(MonthsShort):
                    value = culture.DateTimeFormat.AbbreviatedMonthNames.Select(x => x.NullIfEmpty()).SkipNulls()
                        .ToArray();
                    break;
                case nameof(MonthsParseExact):
                    value = true;
                    break;
                case nameof(Weekdays):
                    value = culture.DateTimeFormat.DayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
                    break;
                case nameof(WeekdaysShort):
                    value = culture.DateTimeFormat.AbbreviatedDayNames.Select(x => x.NullIfEmpty()).SkipNulls()
                        .ToArray();
                    break;
                case nameof(WeekdaysMin):
                    value = culture.DateTimeFormat.ShortestDayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
                    break;
                case nameof(WeekdaysParseExact):
                    value = true;
                    break;
                case nameof(DayOfMonthOrdinalParse):
                    value = new Regex("\\d{1,2}");
                    break;
                case nameof(Ordinal):
                    value = "function (number) { return number; }";
                    break;
                default:
                    value = default;
                    break;
            }

            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}