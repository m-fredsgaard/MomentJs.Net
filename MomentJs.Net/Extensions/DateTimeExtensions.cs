using System;
using Moment.Net.Formats;
using Moment.Net.Formatters;

namespace Moment.Net.Extensions
{
    public static class DateTimeExtensions
    {
        public static string Format<T>(this DateTime dateTime, MomentFormat momentFormat, T locale = null) where T : LocaleDefinition<T>
        {
            return MomentFormatter.Format(dateTime, momentFormat, locale ?? LocaleDefinition<T>.Current);
        }

        public static string Format<T>(this DateTime dateTime, string format, T locale = null) where T : LocaleDefinition<T>
        {
            return MomentFormatter.Format(dateTime, format, locale ?? LocaleDefinition<T>.Current);
        }
    }
}