using System;
using System.Globalization;
using MomentJs.Net.Definitions;
using MomentJs.Net.Formats;
using MomentJs.Net.Formatters;

namespace MomentJs.Net.Extensions
{
    public static class DateTimeExtensions
    {
        public static string Format(this DateTime dateTime, DateFormat dateFormat, CultureInfo culture,
            LocaleDefinition locale = null)
        {
            if (locale == null)
                locale = new LocaleDefinition();

            string format = GetFormat(dateFormat, locale, culture);

            return MomentFormatter.Format(dateTime, format, locale, culture);
        }

        private static string GetFormat(DateFormat dateFormat, LocaleDefinition locale, CultureInfo culture)
        {
            string format;
            switch (dateFormat)
            {
                case DateFormat.LT:
                    format = locale.LongDateFormat.ShortTime(culture);
                    break;
                case DateFormat.LTS:
                    format = locale.LongDateFormat.LongTime(culture);
                    break;
                case DateFormat.L:
                    format = locale.LongDateFormat.ShortDate(culture);
                    break;
                case DateFormat.l:
                    format = locale.LongDateFormat.ShortDateCompact(culture);
                    break;
                case DateFormat.LL:
                    format = locale.LongDateFormat.LongDate(culture);
                    break;
                case DateFormat.ll:
                    format = locale.LongDateFormat.LongDateCompact(culture);
                    break;
                case DateFormat.LLL:
                    format = locale.LongDateFormat.LongDateShortTime(culture);
                    break;
                case DateFormat.lll:
                    format = locale.LongDateFormat.LongDateShortTimeCompact(culture);
                    break;
                case DateFormat.LLLL:
                    format = locale.LongDateFormat.FullDateTime(culture);
                    break;
                case DateFormat.llll:
                    format = locale.LongDateFormat.FullDateTimeCompact(culture);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dateFormat), dateFormat, null);
            }

            return format;
        }
    }
}