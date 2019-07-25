namespace MomentJs.Net.Formats
{
    /// <summary>
    /// </summary>
    /// <remarks>
    ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
    /// </remarks>
    public enum StandardFormat
    {
        /// <summary>
        ///     Short date pattern: 9/4/1986
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#ShortDate
        /// </remarks>
        d,

        /// <summary>
        ///     Long date pattern: Thursday, September 4, 1986
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#LongDate
        /// </remarks>
        D,

        /// <summary>
        ///     Full date/time pattern (short time): Thursday, September 4, 1986 8:30 PM
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#FullDateShortTime
        /// </remarks>
        f,

        /// <summary>
        ///     Full date/time pattern (long time): Thursday, September 4, 1986 8:30:25 PM
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#FullDateLongTime
        /// </remarks>
        F,

        /// <summary>
        ///     General date/time pattern (short time): 9/4/1986 8:30 PM
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#GeneralDateShortTime
        /// </remarks>
        g,

        /// <summary>
        ///     General date/time pattern (long time): 9/4/1986 8:30:25 PM
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#GeneralDateLongTime
        /// </remarks>
        G,

        /// <summary>
        ///     Month/day pattern: September 4
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#MonthDay
        /// </remarks>
        M,

        /// <summary>
        ///     Month/day pattern: September 4
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#MonthDay
        /// </remarks>
        m,

        /// <summary>
        ///     Round-trip date/time pattern: 1986-09-04T20:30:25.0000000+01:00
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#Roundtrip
        /// </remarks>
        O,

        /// <summary>
        ///     Round-trip date/time pattern: 1986-09-04T08:30:25.0000000+01:00
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#Roundtrip
        /// </remarks>
        o,

        /// <summary>
        ///     RFC1123 pattern: Thu, 4 Sep 1986 08:30:25 GMT
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#RFC1123
        /// </remarks>
        R,

        /// <summary>
        ///     RFC1123 pattern: Thu, 4 Sep 1986 08:30:25 GMT
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#RFC1123
        /// </remarks>
        r,

        /// <summary>
        ///     Sortable date/time pattern: 1986-09-04T20:30:25
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#Sortable
        /// </remarks>
        s,

        /// <summary>
        ///     Short time pattern: 8:30 PM
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#ShortTime
        /// </remarks>
        t,

        /// <summary>
        ///     Long time pattern: 8:30:25 PM
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#LongTime
        /// </remarks>
        T,

        /// <summary>
        ///     Universal sortable date/time pattern: 1986-09-04 20:30:25Z
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#UniversalSortable
        /// </remarks>
        u,

        /// <summary>
        ///     Universal full date/time pattern: Thursday, September 4, 1986 8:30:25 PM
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#UniversalFull
        /// </remarks>
        U,

        /// <summary>
        ///     Year month pattern: September, 1986
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#YearMonth
        /// </remarks>
        Y,

        /// <summary>
        ///     Year month pattern: September, 1986
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#YearMonth
        /// </remarks>
        y
    }
}