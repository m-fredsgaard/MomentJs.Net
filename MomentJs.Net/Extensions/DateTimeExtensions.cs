using System;
using MomentJs.Net.Definitions;
using MomentJs.Net.Formats;
using MomentJs.Net.Formatters;

namespace MomentJs.Net.Extensions
{
    public static class DateTimeExtensions
    {
        public static string Format(this DateTime dateTime, DateFormat dateFormat, LocaleDefinition locale)
        {
            string format = GetFormat(dateFormat, locale);

            return MomentFormatter.Format(dateTime, format, locale);
        }

        public static string Format<T>(this DateTime dateTime, string format, T locale = null)
            where T : LocaleDefinition<T>
        {
            return MomentFormatter.Format(dateTime, format, locale ?? LocaleDefinition<T>.Current);
        }

        public static string Format<T>(this DateTime dateTime, DateFormat dateFormat, T locale = null)
            where T : LocaleDefinition<T>
        {
            if (locale == null)
                locale = LocaleDefinition<T>.Current;

            string format = GetFormat(dateFormat, locale);

            return Format(dateTime, format, locale);
        }

        private static string GetFormat(DateFormat dateFormat, LocaleDefinition locale)
        {
            string format;
            switch (dateFormat)
            {
                case DateFormat.LT:
                    format = locale.LongDateFormat.LT();
                    break;
                case DateFormat.LTS:
                    format = locale.LongDateFormat.LTS();
                    break;
                case DateFormat.L:
                    format = locale.LongDateFormat.L();
                    break;
                case DateFormat.l:
                    format = locale.LongDateFormat.l();
                    break;
                case DateFormat.LL:
                    format = locale.LongDateFormat.LL();
                    break;
                case DateFormat.ll:
                    format = locale.LongDateFormat.ll();
                    break;
                case DateFormat.LLL:
                    format = locale.LongDateFormat.LLL();
                    break;
                case DateFormat.lll:
                    format = locale.LongDateFormat.lll();
                    break;
                case DateFormat.LLLL:
                    format = locale.LongDateFormat.LLLL();
                    break;
                case DateFormat.llll:
                    format = locale.LongDateFormat.llll();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dateFormat), dateFormat, null);
            }

            return format;
        }
    }
}