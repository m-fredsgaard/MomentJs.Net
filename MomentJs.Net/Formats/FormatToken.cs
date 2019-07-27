// ReSharper disable InconsistentNaming

namespace MomentJs.Net.Formats
{
    public enum FormatToken
    {
        /// <summary>
        ///     Month: 1 2 ... 11 12
        /// </summary>
        M,

        /// <summary>
        ///     Month: 1st 2nd ... 11th 12th
        /// </summary>
        Mo,

        /// <summary>
        ///     Month: 01 02 ... 11 12
        /// </summary>
        MM,

        /// <summary>
        ///     Month: Jan Feb ... Nov Dec
        /// </summary>
        MMM,

        /// <summary>
        ///     Month: January February ... November December
        /// </summary>
        MMMM,

        /// <summary>
        ///     Quarter: 1 2 3 4
        /// </summary>
        Q,

        /// <summary>
        ///     Quarter: 1st 2nd 3rd 4th
        /// </summary>
        Qo,

        /// <summary>
        ///     Day of Month: 1 2 ... 30 31
        /// </summary>
        D,

        /// <summary>
        ///     Day of Month: 1st 2nd ... 30th 31st
        /// </summary>
        Do,

        /// <summary>
        ///     Day of Month: 01 02 ... 30 31
        /// </summary>
        DD,

        /// <summary>
        ///     Day of Year: 1 2 ... 364 365
        /// </summary>
        DDD,

        /// <summary>
        ///     Day of Year: 1st 2nd ... 364th 365th
        /// </summary>
        DDDo,

        /// <summary>
        ///     Day of Year: 001 002 ... 364 365
        /// </summary>
        DDDD,

        /// <summary>
        ///     Day of Week: 0 1 ... 5 6
        /// </summary>
        d,

        /// <summary>
        ///     Day of Week: 0th 1st ... 5th 6th
        /// </summary>
        @do,

        /// <summary>
        ///     Day of Week: Su Mo ... Fr Sa
        /// </summary>
        dd,

        /// <summary>
        ///     Day of Week: Sun Mon ... Fri Sat
        /// </summary>
        ddd,

        /// <summary>
        ///     Day of Week: Sunday Monday ... Friday Saturday
        /// </summary>
        dddd,

        /// <summary>
        ///     Day of Week (Locale): 0 1 ... 5 6
        /// </summary>
        e,

        /// <summary>
        ///     Day of Week (ISO): 1 2 ... 6 7
        /// </summary>
        E,

        /// <summary>
        ///     Week of Year: 1 2 ... 52 53
        /// </summary>
        w,

        /// <summary>
        ///     Week of Year: 1st 2nd ... 52nd 53rd
        /// </summary>
        wo,

        /// <summary>
        ///     Week of Year: 01 02 ... 52 53
        /// </summary>
        ww,

        /// <summary>
        ///     Week of Year (ISO): 1 2 ... 52 53
        /// </summary>
        W,

        /// <summary>
        ///     Week of Year (ISO): 1st 2nd ... 52nd 53rd
        /// </summary>
        Wo,

        /// <summary>
        ///     Week of Year (ISO): 01 02 ... 52 53
        /// </summary>
        WW,

        /// <summary>
        ///     Year: 70 71 ... 29 30
        /// </summary>
        YY,

        /// <summary>
        ///     Year: 1970 1971 ... 2029 2030
        /// </summary>
        YYYY,

        /// <summary>
        ///     Year: 1970 1971 ... 9999 +10000 +10001
        /// </summary>
        /// <remarks>
        ///     Note: This complies with the ISO 8601 standard for dates past the year 9999
        /// </remarks>
        Y,

        /// <summary>
        ///     Week Year: 70 71 ... 29 30
        /// </summary>
        gg,

        /// <summary>
        ///     Week Year: 1970 1971 ... 2029 2030
        /// </summary>
        gggg,

        /// <summary>
        ///     Week Year (ISO): 70 71 ... 29 30
        /// </summary>
        GG,

        /// <summary>
        ///     Week Year (ISO): 1970 1971 ... 2029 2030
        /// </summary>
        GGGG,

        /// <summary>
        ///     AM/PM: AM PM
        /// </summary>
        A,

        /// <summary>
        ///     AM/PM: am pm
        /// </summary>
        a,

        /// <summary>
        ///     Hour: 0 1 ... 22 23
        /// </summary>
        H,

        /// <summary>
        ///     Hour: 00 01 ... 22 23
        /// </summary>
        HH,

        /// <summary>
        ///     Hour: 1 2 ... 11 12
        /// </summary>
        h,

        /// <summary>
        ///     Hour: 01 02 ... 11 12
        /// </summary>
        hh,

        /// <summary>
        ///     Hour: 1 2 ... 23 24
        /// </summary>
        k,

        /// <summary>
        ///     Hour: 01 02 ... 23 24
        /// </summary>
        kk,

        /// <summary>
        ///     Minute: 0 1 ... 58 59
        /// </summary>
        m,

        /// <summary>
        ///     Minute: 00 01 ... 58 59
        /// </summary>
        mm,

        /// <summary>
        ///     Second: 0 1 ... 58 59
        /// </summary>
        s,

        /// <summary>
        ///     Second: 00 01 ... 58 59
        /// </summary>
        ss,

        /// <summary>
        ///     Fractional Second: 0 1 ... 8 9
        /// </summary>
        S,

        /// <summary>
        ///     Fractional Second: 00 01 ... 98 99
        /// </summary>
        SS,

        /// <summary>
        ///     Fractional Second: 000 001 ... 998 999
        /// </summary>
        SSS,

        /// <summary>
        ///     Fractional Second: 0000 0001 ... 9998 9999
        /// </summary>
        SSSS,

        /// <summary>
        ///     Fractional Second: 00000 00001 ... 99998 99999
        /// </summary>
        SSSSS,

        /// <summary>
        ///     Fractional Second: 000000 000001 ... 999998 999999
        /// </summary>
        SSSSSS,

        /// <summary>
        ///     Fractional Second: 0000000 0000001 ... 9999998 9999999
        /// </summary>
        SSSSSSS,

        /// <summary>
        ///     Fractional Second: 00000000 00000001 ... 99999998 99999999
        /// </summary>
        SSSSSSSS,

        /// <summary>
        ///     Fractional Second: 000000000 000000001 ... 999999998 999999999
        /// </summary>
        SSSSSSSSS,

        /// <summary>
        ///     Time Zone: EST CST ... MST PST
        /// </summary>
        /// <remarks>
        ///     Note: as of 1.6.0, the z/zz format tokens have been deprecated from plain moment objects. [Read more about it
        ///     here](https://github.com/moment/moment/issues/162). However, they *do* work if you are using a specific time zone
        ///     with the moment-timezone addon.
        /// </remarks>
        z,

        /// <summary>
        ///     Time Zone: EST CST ... MST PST
        /// </summary>
        /// <remarks>
        ///     Note: as of 1.6.0, the z/zz format tokens have been deprecated from plain moment objects. [Read more about it
        ///     here](https://github.com/moment/moment/issues/162). However, they *do* work if you are using a specific time zone
        ///     with the moment-timezone addon.
        /// </remarks>
        zz,

        /// <summary>
        ///     Time Zone: -07:00 -06:00 ... +06:00 +07:00
        /// </summary>
        Z,

        /// <summary>
        ///     Time Zone: -0700 -0600 ... +0600 +0700
        /// </summary>
        ZZ,

        /// <summary>
        ///     Unix Timestamp: 1360013296
        /// </summary>
        X,

        /// <summary>
        ///     Unix Millisecond Timestamp: 1360013296123
        /// </summary>
        x
    }
}