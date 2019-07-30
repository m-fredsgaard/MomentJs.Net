using MomentJs.Net.Converters;
using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class Week
    {
        public Week()
        {
            FirstDayOfWeek = FirstDayOfWeekDefaultValue;
            FirstWeekOfYear = FirstWeekOfYearDefaultValue;
        }

        /// <summary>
        ///     Is representing the first day of the week, 0 is Sunday, 1 is Monday, ..., 6 is Saturday
        /// </summary>
        [JsonProperty("dow", Order = 1)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<int> FirstDayOfWeek { get; set; }

        public static LocaleDefinition.ValueResolver<int> FirstDayOfWeekDefaultValue =>
            culture => (int) culture.DateTimeFormat.FirstDayOfWeek;

        /// <summary>
        ///     Is used together with <see cref="FirstDayOfWeek" /> to determine the first week of the year. FirstWeekOfYear is
        ///     calculated as 7 + <see cref="FirstDayOfWeek" /> - janX, where janX is the first day of January that must belong to
        ///     the first week of the year.
        /// </summary>
        [JsonProperty("doy", Order = 2)]
        [JsonConverter(typeof(LocaleResolverJsonConverter))]
        public LocaleDefinition.ValueResolver<int> FirstWeekOfYear { get; set; }

        // FirstWeekOfYear is calculated as 7 + <see cref="FirstDayOfWeek"/> - janX, where janX is the first day of January that must belong to the first week of the year.
        public static LocaleDefinition.ValueResolver<int> FirstWeekOfYearDefaultValue =>
            culture => 7 + (int) culture.DateTimeFormat.FirstDayOfWeek - 1;
    }
}