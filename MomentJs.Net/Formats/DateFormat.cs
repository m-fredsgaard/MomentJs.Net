// ReSharper disable InconsistentNaming

namespace MomentJs.Net.Formats
{
    public enum DateFormat
    {
        /// <summary>
        ///     Time: 8:30 PM
        /// </summary>
        LT,

        /// <summary>
        ///     Time with seconds: 8:30:25 PM
        /// </summary>
        LTS,

        /// <summary>
        ///     Month numeral, day of month, year: 09/04/1986
        /// </summary>
        L,

        /// <summary>
        ///     Month numeral, day of month, year: 9/4/1986
        /// </summary>
        l,

        /// <summary>
        ///     Month name, day of month, year: September 4, 1986
        /// </summary>
        LL,

        /// <summary>
        ///     Month name, day of month, year: Sep 4, 1986
        /// </summary>
        ll,

        /// <summary>
        ///     Month name, day of month, year, time: September 4, 1986 8:30 PM
        /// </summary>
        LLL,

        /// <summary>
        ///     Month name, day of month, year, time: Sep 4, 1986 8:30 PM
        /// </summary>
        lll,

        /// <summary>
        ///     Month name, day of month, day of week, year, time: Thursday, September 4, 1986 8:30 PM
        /// </summary>
        LLLL,

        /// <summary>
        ///     Month name, day of month, day of week, year, time: Thu, Sep 4, 1986 8:30 PM
        /// </summary>
        llll
    }
}