using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Moment.Net.Converters;
using Moment.Net.Extensions;
using Moment.Net.Formats;
using Newtonsoft.Json;

namespace Moment.Net
{
    public class StandardLocaleDefinition : LocaleDefinition
    {
        public StandardLocaleDefinition(CultureInfo culture, Func<int, string> ordinal = null) : base(culture, ordinal)
        { }

        public StandardLocaleDefinition(string cultureName, Func<int, string> ordinal = null) : base(cultureName, ordinal)
        { }
    }

    public class LocaleDefinition<T> : LocaleDefinition
        where T: LocaleDefinition
    {
        private static T _current;

        public static T Current
        {
            get
            {
                if(_current == null || _current.Culture.Name == CultureInfo.CurrentCulture.Name)
                    _current = typeof(T).GetConstructor(new Type[]{typeof(CultureInfo)})?.Invoke(new object[]{CultureInfo.CurrentCulture}) as T;

                return _current;
            }
        }

        protected LocaleDefinition(CultureInfo culture, Func<int, string> ordinal = null) : base(culture, ordinal)
        { }

        public LocaleDefinition(string cultureName, Func<int, string> ordinal = null) : base(cultureName, ordinal)
        { }
    }

    public abstract class LocaleDefinition
    {
        [JsonIgnore]
        public CultureInfo Culture { get; }

        [JsonProperty("months", Order = 1)]
        public string[] Months { get; set; }
        
        [JsonProperty("monthsShort", Order = 2)]
        
        public string[] MonthsShort { get; set; }
        
        [JsonProperty("monthsParseExact", Order = 3)]
        public bool MonthsParseExact { get; set; }

        [JsonProperty("weekdays", Order = 4)]
        public string[] Weekdays { get; set; }

        [JsonProperty("weekdaysShort", Order = 5)]
        public string[] WeekdaysShort { get; set; }

        [JsonProperty("weekdaysMin", Order = 6)]
        public string[] WeekdaysMin { get; set; }

        [JsonProperty("weekdaysParseExact", Order = 7)]
        public bool WeekdaysParseExact { get; set; }

        [JsonProperty("longDateFormat", Order = 8)]
        public LongDateFormat LongDateFormat { get; set; }

        [JsonProperty("calendar", Order = 9)]
        public Calendar Calendar { get; set; }

        [JsonProperty("relativeTime", Order = 10)]
        public RelativeTime RelativeTime { get; set; }

        [JsonProperty("dayOfMonthOrdinalParse", Order = 11)]
        public Regex DayOfMonthOrdinalParse { get; set; }

        [JsonProperty("ordinal", Order = 12)]
        public string Ordinal { get; set; }

        [JsonProperty("week", Order = 13)]
        public Week Week { get; set; }

        protected LocaleDefinition(CultureInfo culture, Func<int, string> ordinal = null)
        {
            Culture = culture;

            Months = culture.DateTimeFormat.MonthNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            MonthsShort = culture.DateTimeFormat.AbbreviatedMonthNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            MonthsParseExact = true;
            Weekdays = culture.DateTimeFormat.DayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            WeekdaysShort = culture.DateTimeFormat.AbbreviatedDayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            WeekdaysMin = culture.DateTimeFormat.ShortestDayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
            WeekdaysParseExact = true;
            LongDateFormat = new LongDateFormat
            {
                LT = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortTimePattern, this, MomentFormat.LT),
                LTS = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongTimePattern, this, MomentFormat.LTS),
                L = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, this, MomentFormat.L),
                LL = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, this, MomentFormat.LL),
                LLL = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, this, MomentFormat.LLL),
                LLLL = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, this, MomentFormat.LLLL),
                l = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, this, MomentFormat.l),
                ll = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, this, MomentFormat.ll),
                lll = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, this, MomentFormat.lll),
                llll = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, this, MomentFormat.llll)
            };
            Calendar = new Calendar();
            RelativeTime = new RelativeTime();
            DayOfMonthOrdinalParse = new Regex("");
            Ordinal = string.Empty;
            Week = new Week
            {
                FirstDayOfWeek = (int)culture.DateTimeFormat.FirstDayOfWeek,
                // FirstWeekOfYear is calculated as 7 + <see cref="FirstDayOfWeek"/> - janX, where janX is the first day of January that must belong to the first week of the year.
                FirstWeekOfYear = 7 + (int)culture.DateTimeFormat.FirstDayOfWeek - 1
            };
            //Ordinal = ordinal ?? (Ordinals.ContainsKey(cultureInfo.Name) ? Ordinals[cultureInfo.Name] : i => null);
        }

        protected LocaleDefinition(string cultureName, Func<int, string> ordinal = null)
            : this(new CultureInfo(cultureName), ordinal)
        { }


        //[Obsolete("Use MomentDefinition.Ordinal instead.")]
        //public Func<int, string> FormatOrdinal { get; }

        public string FormatOrdinal(int value)
        {
            var ordinal = (Ordinals.ContainsKey(Culture.Name) ? Ordinals[Culture.Name] : null);
            return ordinal?.Invoke(value) ?? null;
        }
        //public LocaleDefinition LocaleDefinition { get; }

        private static readonly Dictionary<string, Func<int, string>> Ordinals = new Dictionary<string, Func<int, string>>()
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
    }

    //public class LocaleDefinition
    //{
        
        

        

    //    public LocaleDefinition(CultureDefinition culture)
    //    {
    //        //Months = culture.DateTimeFormat.MonthNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
    //        //MonthsShort = culture.DateTimeFormat.AbbreviatedMonthNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
    //        //MonthsParseExact = true;
    //        //Weekdays = culture.DateTimeFormat.DayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
    //        //WeekdaysShort = culture.DateTimeFormat.AbbreviatedDayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
    //        //WeekdaysMin = culture.DateTimeFormat.ShortestDayNames.Select(x => x.NullIfEmpty()).SkipNulls().ToArray();
    //        //WeekdaysParseExact = true;
    //        //LongDateFormat = new LongDateFormat
    //        //{
    //        //    LT = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortTimePattern, culture, MomentFormat.LT),
    //        //    LTS = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongTimePattern, culture, MomentFormat.LTS),
    //        //    L = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, culture, MomentFormat.L),
    //        //    LL = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, culture, MomentFormat.LL),
    //        //    LLL = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, culture, MomentFormat.LLL),
    //        //    LLLL = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, culture, MomentFormat.LLLL),
    //        //    l = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.ShortDatePattern, culture, MomentFormat.l),
    //        //    ll = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern, culture, MomentFormat.ll),
    //        //    lll = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.LongDatePattern + " " + culture.DateTimeFormat.ShortTimePattern, culture, MomentFormat.lll),
    //        //    llll = PatternConverter.ConvertToMomentPattern(culture.DateTimeFormat.FullDateTimePattern, culture, MomentFormat.llll)
    //        //};
    //        //Calendar = new Calendar();
    //        //RelativeTime = new RelativeTime();
    //        //DayOfMonthOrdinalParse = new Regex("");
    //        //Ordinal = string.Empty;
    //        //Week = new Week
    //        //{
    //        //    FirstDayOfWeek = (int)culture.DateTimeFormat.FirstDayOfWeek,
    //        //    // FirstWeekOfYear is calculated as 7 + <see cref="FirstDayOfWeek"/> - janX, where janX is the first day of January that must belong to the first week of the year.
    //        //    FirstWeekOfYear = 7 + (int)culture.DateTimeFormat.FirstDayOfWeek - 1
    //        //};
    //    }
    //}

    public class LongDateFormat
    {
        [JsonProperty("LT", Order = 1)]
        public string LT { get; set; }

        [JsonProperty("LTS", Order = 2)]
        public string LTS { get; set; }

        [JsonProperty("L", Order = 3)]
        public string L { get; set; }

        [JsonProperty("LL", Order = 4)]
        public string LL { get; set; }
        
        [JsonProperty("LLL", Order = 5)]
        public string LLL { get; set; }
        
        [JsonProperty("LLLL", Order = 6)]
        public string LLLL { get; set; }

        [JsonIgnore]
        public string l { get; set; }
        
        [JsonIgnore]
        public string ll { get; set; }
        
        [JsonIgnore]
        public string lll { get; set; }
        
        [JsonIgnore]
        public string llll { get; set; }
    }

    public class Calendar
    {
        [JsonProperty("sameDay", Order = 1)]
        public string SameDay { get; set; }

        [JsonProperty("nextDay", Order = 2)]
        public string NextDay { get; set; }
        
        [JsonProperty("nextWeek", Order = 3)]
        public string NextWeek { get; set; }
        
        [JsonProperty("lastDay", Order = 4)]
        public string LastDay { get; set; }

        [JsonProperty("lastWeek", Order = 5)]
        public string LastWeek { get; set; }

        [JsonProperty("sameElse", Order = 6)]
        public string SameElse { get; set; }
    }

    public class RelativeTime
    {
        [JsonProperty("future", Order = 1)]
        public string Future { get; set; }
        
        [JsonProperty("past", Order = 2)]
        public string Past { get; set; }

        [JsonProperty("s", Order = 3)]
        public string Second { get; set; }

        [JsonProperty("ss", Order = 4)]
        public string Seconds { get; set; }

        [JsonProperty("m", Order = 5)]
        public string Minute { get; set; }

        [JsonProperty("mm", Order = 6)]
        public string Minutes { get; set; }

        [JsonProperty("h", Order = 7)]
        public string Hour { get; set; }

        [JsonProperty("hh", Order = 8)]
        public string Hours { get; set; }

        [JsonProperty("d", Order = 9)]
        public string Day { get; set; }

        [JsonProperty("dd", Order = 10)]
        public string Days { get; set; }

        [JsonProperty("M", Order = 11)]
        public string Month { get; set; }

        [JsonProperty("MM", Order = 12)]
        public string Months { get; set; }

        [JsonProperty("y", Order = 13)]
        public string Year { get; set; }

        [JsonProperty("yy", Order = 14)]
        public string Years { get; set; }
    }

    public class Week
    {
        /// <summary>
        /// Is representing the first day of the week, 0 is Sunday, 1 is Monday, ..., 6 is Saturday
        /// </summary>
        [JsonProperty("dow", Order = 1)]
        public int FirstDayOfWeek { get; set; }
        
        /// <summary>
        /// Is used together with <see cref="FirstDayOfWeek"/> to determine the first week of the year. FirstWeekOfYear is calculated as 7 + <see cref="FirstDayOfWeek"/> - janX, where janX is the first day of January that must belong to the first week of the year.
        /// </summary>
        [JsonProperty("doy", Order = 2)]
        public int FirstWeekOfYear { get; set; }
    }
    
}