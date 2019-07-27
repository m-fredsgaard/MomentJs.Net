using System.Globalization;
using System.Linq;
using System.Reflection;
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

        protected LocaleDefinition(CultureInfo culture) : base(culture)
        {
        }

        // ReSharper disable once MemberCanBeProtected.Global
        public LocaleDefinition(string culture) : base(culture)
        {
        }

        public static T Current
        {
            get
            {
                if (_current != null && _current.Culture.Name == CultureInfo.CurrentCulture.Name)
                    return _current;

                ConstructorInfo constructor = typeof(T).GetConstructor(new[] {typeof(CultureInfo)});
                if (constructor != null)
                {
                    _current = constructor.Invoke(new object[] {CultureInfo.CurrentCulture}) as T;
                }
                else
                {
                    constructor = typeof(T).GetConstructor(new[] {typeof(string)});
                    if (constructor != null)
                        _current = constructor.Invoke(new object[] {CultureInfo.CurrentCulture.Name}) as T;
                }

                return _current;
            }
        }
    }

    public abstract class LocaleDefinition
    {
        public delegate T ValueResolver<out T>();

        protected LocaleDefinition(CultureInfo culture)
        {
            Culture = culture;

            Months = () => culture.DateTimeFormat.MonthNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            MonthsShort = () => culture.DateTimeFormat.AbbreviatedMonthNames.Select(x => x.NullIfEmpty()).SkipNulls()
                .ToArray();
            MonthsParseExact = () => true;
            Weekdays = () => culture.DateTimeFormat.DayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            WeekdaysShort = () => culture.DateTimeFormat.AbbreviatedDayNames.Select(x => x.NullIfEmpty()).SkipNulls()
                .ToArray();
            WeekdaysMin = () =>
                culture.DateTimeFormat.ShortestDayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            WeekdaysParseExact = () => true;
            LongDateFormat = new LongDateFormat
            {
                LT = () => PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortTimePattern, this,
                    DateFormat.LT),
                LTS = () => PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongTimePattern, this,
                    DateFormat.LTS),
                L = () => PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, this,
                    DateFormat.L),
                LL = () => PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, this,
                    DateFormat.LL),
                LLL = () => PatternConverter.ConvertToMomentPattern(
                    culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, this,
                    DateFormat.LLL),
                LLLL = () => PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, this,
                    DateFormat.LLLL),
                l = () => PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, this,
                    DateFormat.l),
                ll = () => PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, this,
                    DateFormat.ll),
                lll = () => PatternConverter.ConvertToMomentPattern(
                    culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, this,
                    DateFormat.lll),
                llll = () => PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, this,
                    DateFormat.llll)
            };
            Calendar = new Calendar();
            RelativeTime = new RelativeTime();
            DayOfMonthOrdinalParse = () => new Regex("\\d{1,2}");
            Ordinal = () => "function (number) { return number; }";
            Week = new Week
            {
                FirstDayOfWeek = () => (int) culture.DateTimeFormat.FirstDayOfWeek,
                // FirstWeekOfYear is calculated as 7 + <see cref="FirstDayOfWeek"/> - janX, where janX is the first day of January that must belong to the first week of the year.
                FirstWeekOfYear = () => 7 + (int) culture.DateTimeFormat.FirstDayOfWeek - 1
            };
        }

        protected LocaleDefinition(string cultureName)
            : this(new CultureInfo(cultureName))
        {
        }

        [JsonIgnore] public CultureInfo Culture { get; }

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
    }
}