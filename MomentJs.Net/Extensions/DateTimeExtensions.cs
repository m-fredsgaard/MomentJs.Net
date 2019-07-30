using System;
using System.Globalization;
using MomentJs.Net.Formats;
using MomentJs.Net.Formatters;
using MomentJs.Net.Globalization;

namespace MomentJs.Net.Extensions
{
    public static class DateTimeExtensions
    {
        public static string Format(this DateTime dateTime, CultureInfo culture = null)
        {
            if (culture == null)
                culture = CultureInfo.CurrentCulture;
            
            return MomentFormatter.Format(dateTime, "YYYY-MM-DD[T]HH:mm:ssZ", culture);
        }

        public static string Format(this DateTime dateTime, string format, CultureInfo culture = null)
        {
            if (culture == null)
                culture = CultureInfo.CurrentCulture;
            
            return MomentFormatter.Format(dateTime, format, culture);
        }

        public static string Format(this DateTime dateTime, DateFormat dateFormat, CultureInfo culture = null)
        {
            GlobalizationProvider globalizationProvider = GlobalizationProvider.Instance;
            if (culture == null)
                culture = CultureInfo.CurrentCulture;

            string format;
            switch (dateFormat)
            {
                case DateFormat.LT:
                    format = globalizationProvider.LongDateFormat.ShortTime(culture);
                    break;
                case DateFormat.LTS:
                    format = globalizationProvider.LongDateFormat.LongTime(culture);
                    break;
                case DateFormat.L:
                    format = globalizationProvider.LongDateFormat.ShortDate(culture);
                    break;
                case DateFormat.l:
                    format = globalizationProvider.LongDateFormat.ShortDateCompact(culture);
                    break;
                case DateFormat.LL:
                    format = globalizationProvider.LongDateFormat.LongDate(culture);
                    break;
                case DateFormat.ll:
                    format = globalizationProvider.LongDateFormat.LongDateCompact(culture);
                    break;
                case DateFormat.LLL:
                    format = globalizationProvider.LongDateFormat.LongDateShortTime(culture);
                    break;
                case DateFormat.lll:
                    format = globalizationProvider.LongDateFormat.LongDateShortTimeCompact(culture);
                    break;
                case DateFormat.LLLL:
                    format = globalizationProvider.LongDateFormat.FullDateTime(culture);
                    break;
                case DateFormat.llll:
                    format = globalizationProvider.LongDateFormat.FullDateTimeCompact(culture);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dateFormat), dateFormat, null);
            }

            return MomentFormatter.Format(dateTime, format, culture);
        }
    }
}