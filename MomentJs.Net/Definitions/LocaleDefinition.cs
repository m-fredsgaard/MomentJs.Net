using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using MomentJs.Net.Converters;
using MomentJs.Net.Extensions;
using MomentJs.Net.Formats;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class LocaleDefinition<T> : LocaleDefinition
        where T : LocaleDefinition
    {
        private static T _current;

        protected LocaleDefinition(CultureInfo culture, Func<int, string> ordinal = null) : base(culture, ordinal)
        {
        }

        public LocaleDefinition(string cultureName, Func<int, string> ordinal = null) : base(cultureName, ordinal)
        {
        }

        public static T Current
        {
            get
            {
                if (_current == null || _current.Culture.Name == CultureInfo.CurrentCulture.Name)
                    _current = typeof(T).GetConstructor(new[] {typeof(CultureInfo)})
                        ?.Invoke(new object[] {CultureInfo.CurrentCulture}) as T;

                return _current;
            }
        }
    }

    public abstract class LocaleDefinition
    {
        private static readonly Dictionary<string, Func<int, string>> Ordinals =
            new Dictionary<string, Func<int, string>>
            {
                {
                    "en-US", i =>
                    {
                        int b = i % 10;
                        string output = i % 100 / 10 == 1 ? "th" : b == 1 ? "st" : b == 2 ? "nd" : b == 3 ? "rd" : "th";
                        return $"{i}{output}";
                    }
                },
                {
                    "da-DK", i => $"{i}."
                }
            };

        protected LocaleDefinition(CultureInfo culture, Func<int, string> ordinal = null)
        {
            Culture = culture;

            Months = culture.DateTimeFormat.MonthNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            MonthsShort = culture.DateTimeFormat.AbbreviatedMonthNames.Select(x => x.NullIfEmpty()).SkipNulls()
                .ToArray();
            MonthsParseExact = true;
            Weekdays = culture.DateTimeFormat.DayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            WeekdaysShort = culture.DateTimeFormat.AbbreviatedDayNames.Select(x => x.NullIfEmpty()).SkipNulls()
                .ToArray();
            WeekdaysMin = culture.DateTimeFormat.ShortestDayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            WeekdaysParseExact = true;
            LongDateFormat = new LongDateFormat
            {
                LT = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortTimePattern, this,
                    MomentFormat.LT),
                LTS = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongTimePattern, this,
                    MomentFormat.LTS),
                L = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, this,
                    MomentFormat.L),
                LL = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, this,
                    MomentFormat.LL),
                LLL = PatternConverter.ConvertToMomentPattern(
                    culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, this,
                    MomentFormat.LLL),
                LLLL = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, this,
                    MomentFormat.LLLL),
                l = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, this,
                    MomentFormat.l),
                ll = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, this,
                    MomentFormat.ll),
                lll = PatternConverter.ConvertToMomentPattern(
                    culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, this,
                    MomentFormat.lll),
                llll = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, this,
                    MomentFormat.llll)
            };
            Calendar = new Calendar();
            RelativeTime = new RelativeTime();
            DayOfMonthOrdinalParse = new Regex("");
            Ordinal = string.Empty;
            Week = new Week
            {
                FirstDayOfWeek = (int) culture.DateTimeFormat.FirstDayOfWeek,
                // FirstWeekOfYear is calculated as 7 + <see cref="FirstDayOfWeek"/> - janX, where janX is the first day of January that must belong to the first week of the year.
                FirstWeekOfYear = 7 + (int) culture.DateTimeFormat.FirstDayOfWeek - 1
            };
        }

        protected LocaleDefinition(string cultureName, Func<int, string> ordinal = null)
            : this(new CultureInfo(cultureName), ordinal)
        {
        }

        [JsonIgnore] public CultureInfo Culture { get; }

        [JsonProperty("months", Order = 1)] public string[] Months { get; set; }

        [JsonProperty("monthsShort", Order = 2)]

        public string[] MonthsShort { get; set; }

        [JsonProperty("monthsParseExact", Order = 3)]
        public bool MonthsParseExact { get; set; }

        [JsonProperty("weekdays", Order = 4)] public string[] Weekdays { get; set; }

        [JsonProperty("weekdaysShort", Order = 5)]
        public string[] WeekdaysShort { get; set; }

        [JsonProperty("weekdaysMin", Order = 6)]
        public string[] WeekdaysMin { get; set; }

        [JsonProperty("weekdaysParseExact", Order = 7)]
        public bool WeekdaysParseExact { get; set; }

        [JsonProperty("longDateFormat", Order = 8)]
        public LongDateFormat LongDateFormat { get; set; }

        [JsonProperty("calendar", Order = 9)] public Calendar Calendar { get; set; }

        [JsonProperty("relativeTime", Order = 10)]
        public RelativeTime RelativeTime { get; set; }

        [JsonProperty("dayOfMonthOrdinalParse", Order = 11)]
        public Regex DayOfMonthOrdinalParse { get; set; }

        [JsonProperty("ordinal", Order = 12)] public string Ordinal { get; set; }

        [JsonProperty("week", Order = 13)] public Week Week { get; set; }

        public string FormatOrdinal(int value)
        {
            var ordinal = Ordinals.ContainsKey(Culture.Name) ? Ordinals[Culture.Name] : null;
            return ordinal?.Invoke(value) ?? null;
        }
    }
}