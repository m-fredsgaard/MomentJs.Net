using System;
using System.Globalization;
using MomentJs.Net.Converters;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class Week
    {
        public Week()
        {
            FirstDayOfWeek = culture => GetDefaultValue<int>(nameof(FirstDayOfWeek), culture);
            FirstWeekOfYear = culture => GetDefaultValue<int>(nameof(FirstWeekOfYear), culture);
            ;
        }

        /// <summary>
        ///     Is representing the first day of the week, 0 is Sunday, 1 is Monday, ..., 6 is Saturday
        /// </summary>
        [JsonProperty("dow", Order = 1)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<int> FirstDayOfWeek { get; set; }

        /// <summary>
        ///     Is used together with <see cref="FirstDayOfWeek" /> to determine the first week of the year. FirstWeekOfYear is
        ///     calculated as 7 + <see cref="FirstDayOfWeek" /> - janX, where janX is the first day of January that must belong to
        ///     the first week of the year.
        /// </summary>
        [JsonProperty("doy", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<int> FirstWeekOfYear { get; set; }

        protected static T GetDefaultValue<T>(string type, CultureInfo culture)
        {
            object value;
            switch (type)
            {
                case nameof(FirstDayOfWeek):
                    value = (int) culture.DateTimeFormat.FirstDayOfWeek;
                    break;
                case nameof(FirstWeekOfYear):
                    // FirstWeekOfYear is calculated as 7 + <see cref="FirstDayOfWeek"/> - janX, where janX is the first day of January that must belong to the first week of the year.
                    value = 7 + (int) culture.DateTimeFormat.FirstDayOfWeek - 1;
                    break;
                default:
                    value = default;
                    break;
            }

            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}