﻿using System;
using System.Globalization;
using System.Text;
using MomentJs.Net.Exceptions;
using MomentJs.Net.Formats;
using MomentJs.Net.Globalization;

// ReSharper disable InconsistentNaming

namespace MomentJs.Net.Formatters
{
    public static class MomentFormatter
    {
        internal static string Format(DateTime dateTime, FormatToken formatToken, CultureInfo culture)
        {
            return Format(dateTime, formatToken.ToString(), culture);
        }

        public static string Format(DateTime dateTime, string format, CultureInfo culture)
        {
            if (format == null)
                return null;

            StringBuilder resultBuilder = new StringBuilder();

            State state = State.None;
            StringBuilder tokenBuffer = new StringBuilder();

            var changeState = new Func<State, State, State>((currentState, newState) =>
            {
                switch (currentState)
                {
                    case State.M:
                        resultBuilder.Append(dateTime.Month);
                        break;
                    case State.Mo:
                        resultBuilder.Append(GlobalizationProvider.Instance.Ordinal(culture).Format(dateTime.Month));
                        break;
                    case State.MM:
                        resultBuilder.Append(dateTime.Month.ToString().PadLeft(2, '0'));
                        break;
                    case State.MMM:
                        resultBuilder.Append(GlobalizationProvider.Instance.MonthsShort(culture)[dateTime.Month - 1]);
                        break;
                    case State.MMMM:
                        resultBuilder.Append(GlobalizationProvider.Instance.Months(culture)[dateTime.Month - 1]);
                        break;
                    case State.Q:
                        resultBuilder.Append((int) Math.Ceiling(dateTime.Month / 3.0));
                        break;
                    case State.Qo:
                        resultBuilder.Append(GlobalizationProvider.Instance.Ordinal(culture)
                            .Format((int) Math.Ceiling(dateTime.Month / 3.0)));
                        break;
                    case State.D:
                        resultBuilder.Append(dateTime.Day);
                        break;
                    case State.Do:
                        resultBuilder.Append(GlobalizationProvider.Instance.Ordinal(culture).Format(dateTime.Day));
                        break;
                    case State.DD:
                        resultBuilder.Append(dateTime.Day.ToString().PadLeft(2, '0'));
                        break;
                    case State.DDD:
                        resultBuilder.Append(dateTime.DayOfYear);
                        break;
                    case State.DDDo:
                        resultBuilder.Append(GlobalizationProvider.Instance.Ordinal(culture)
                            .Format(dateTime.DayOfYear));
                        break;
                    case State.DDDD:
                        resultBuilder.Append(dateTime.DayOfYear.ToString().PadLeft(3, '0'));
                        break;
                    case State.d:
                        resultBuilder.Append((int) dateTime.DayOfWeek);
                        break;
                    case State.@do:
                        resultBuilder.Append(GlobalizationProvider.Instance.Ordinal(culture)
                            .Format((int) dateTime.DayOfWeek));
                        break;
                    case State.dd:
                        resultBuilder.Append(
                            GlobalizationProvider.Instance.WeekdaysMin(culture)[(int) dateTime.DayOfWeek]);
                        break;
                    case State.ddd:
                        resultBuilder.Append(
                            GlobalizationProvider.Instance.WeekdaysShort(culture)[(int) dateTime.DayOfWeek]);
                        break;
                    case State.dddd:
                        resultBuilder.Append(
                            GlobalizationProvider.Instance.Weekdays(culture)[(int) dateTime.DayOfWeek]);
                        break;
                    case State.e:
                        resultBuilder.Append((int) dateTime.DayOfWeek);
                        break;
                    case State.E:
                        int dayOfWeek = (int) dateTime.DayOfWeek - (int) culture.DateTimeFormat.FirstDayOfWeek;
                        if (dayOfWeek < 0)
                            dayOfWeek = 7 + dayOfWeek;
                        resultBuilder.Append(dayOfWeek);
                        break;
                    case State.w:
                    case State.W:
                        resultBuilder.Append(culture.Calendar.GetWeekOfYear(dateTime,
                            culture.DateTimeFormat.CalendarWeekRule,
                            culture.DateTimeFormat.FirstDayOfWeek));
                        break;
                    case State.wo:
                    case State.Wo:
                        resultBuilder.Append(GlobalizationProvider.Instance.Ordinal(culture).Format(
                            culture.Calendar.GetWeekOfYear(dateTime,
                                culture.DateTimeFormat.CalendarWeekRule,
                                culture.DateTimeFormat.FirstDayOfWeek)));
                        break;
                    case State.ww:
                    case State.WW:
                        resultBuilder.Append(culture.Calendar.GetWeekOfYear(dateTime,
                            culture.DateTimeFormat.CalendarWeekRule,
                            culture.DateTimeFormat.FirstDayOfWeek).ToString().PadLeft(2, '0'));
                        break;
                    case State.Y:
                        resultBuilder.Append(dateTime.Year.ToString());
                        break;
                    case State.YY:
                        resultBuilder.Append(dateTime.Year.ToString().Substring(2));
                        break;
                    case State.YYY:
                        resultBuilder.Append(dateTime.Year.ToString().Substring(2));
                        resultBuilder.Append("Y");
                        break;
                    case State.YYYY:
                        if (dateTime.Year > 9999)
                            throw new UnsupportedFormatException(
                                "The YYYY format doesn't support years above 9999. Use Y instead.");
                        resultBuilder.Append(dateTime.Year.ToString());
                        break;
                    case State.gg:
                        resultBuilder.Append(dateTime.Year.ToString().Substring(2));
                        break;
                    case State.ggg:
                        resultBuilder.Append(dateTime.Year.ToString().Substring(2));
                        resultBuilder.Append("g");
                        break;
                    case State.gggg:
                        if (dateTime.Year > 9999)
                            throw new UnsupportedFormatException(
                                "The gggg format doesn't support years above 9999. Use Y instead.");
                        resultBuilder.Append(dateTime.Year.ToString());
                        break;
                    case State.GG:
                        resultBuilder.Append(dateTime.Year.ToString().Substring(2));
                        break;
                    case State.GGG:
                        resultBuilder.Append(dateTime.Year.ToString().Substring(2));
                        resultBuilder.Append("G");
                        break;
                    case State.GGGG:
                        if (dateTime.Year > 9999)
                            throw new UnsupportedFormatException(
                                "The gggg format doesn't support years above 9999. Use Y instead.");
                        resultBuilder.Append(dateTime.Year.ToString());
                        break;
                    case State.A:
                        resultBuilder.Append(dateTime.TimeOfDay >= TimeSpan.Zero &&
                                             dateTime.TimeOfDay < TimeSpan.FromHours(12)
                            ? culture.DateTimeFormat.AMDesignator.ToUpper()
                            : culture.DateTimeFormat.PMDesignator.ToUpper());
                        break;
                    case State.a:
                        resultBuilder.Append(dateTime.TimeOfDay >= TimeSpan.Zero &&
                                             dateTime.TimeOfDay < TimeSpan.FromHours(12)
                            ? culture.DateTimeFormat.AMDesignator.ToLower()
                            : culture.DateTimeFormat.PMDesignator.ToLower());
                        break;
                    case State.H:
                        resultBuilder.Append(dateTime.Hour);
                        break;
                    case State.HH:
                        resultBuilder.Append(dateTime.Hour.ToString().PadLeft(2, '0'));
                        break;
                    case State.h:
                        int h = dateTime.TimeOfDay < TimeSpan.FromHours(12)
                            ? dateTime.Hour
                            : dateTime.Hour - 12;
                        resultBuilder.Append(h);
                        break;
                    case State.hh:
                        int hh = dateTime.TimeOfDay < TimeSpan.FromHours(12)
                            ? dateTime.Hour
                            : dateTime.Hour - 12;
                        resultBuilder.Append(hh.ToString().PadLeft(2, '0'));
                        break;
                    case State.k:
                        resultBuilder.Append(dateTime.Hour + 1);
                        break;
                    case State.kk:
                        resultBuilder.Append((dateTime.Hour + 1).ToString().PadLeft(2, '0'));
                        break;
                    case State.m:
                        resultBuilder.Append(dateTime.Minute);
                        break;
                    case State.mm:
                        resultBuilder.Append(dateTime.Minute.ToString().PadLeft(2, '0'));
                        break;
                    case State.s:
                        resultBuilder.Append(dateTime.Second);
                        break;
                    case State.ss:
                        resultBuilder.Append(dateTime.Second.ToString().PadLeft(2, '0'));
                        break;
                    case State.S:
                        string valueS = dateTime.Millisecond.ToString();
                        resultBuilder.Append(valueS.Substring(0, Math.Min(valueS.Length, 1)).PadLeft(1, '0'));
                        break;
                    case State.SS:
                        string upperS2 = dateTime.Millisecond.ToString();
                        resultBuilder.Append(upperS2.Substring(0, Math.Min(upperS2.Length, 2)).PadLeft(2, '0'));
                        break;
                    case State.SSS:
                        string upperS3 = dateTime.Millisecond.ToString();
                        resultBuilder.Append(upperS3.Substring(0, Math.Min(upperS3.Length, 3)).PadLeft(3, '0'));
                        break;
                    case State.Z:
                        TimeSpan upperZ = new DateTimeOffset(dateTime).Offset;
                        resultBuilder.Append(upperZ < TimeSpan.Zero ? "-" : "+");
                        resultBuilder.Append($"{upperZ.Hours.ToString().PadLeft(2, '0')}:00");
                        break;
                    case State.ZZ:
                        TimeSpan upperZ2 = new DateTimeOffset(dateTime).Offset;
                        resultBuilder.Append(upperZ2 < TimeSpan.Zero ? "-" : "+");
                        resultBuilder.Append($"{upperZ2.Hours.ToString().PadLeft(2, '0')}00");
                        break;
                    case State.X:
                        DateTimeOffset upperX = new DateTimeOffset(dateTime);
                        resultBuilder.Append(upperX.ToUnixTimeSeconds());
                        break;
                    case State.x:
                        DateTimeOffset x = new DateTimeOffset(dateTime);
                        resultBuilder.Append(x.ToUnixTimeMilliseconds());
                        break;
                    case State.LT:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "LT")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture), culture));
                        break;
                    case State.LTS:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "LTS")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.LongTime(culture), culture));
                        break;
                    case State.L:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "L")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.ShortDate(culture), culture));
                        break;
                    case State.LL:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "LL")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.LongDate(culture), culture));
                        break;
                    case State.LLL:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "LLL")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.LongDateShortTime(culture), culture));
                        break;
                    case State.LLLL:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "LLLL")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.FullDateTime(culture), culture));
                        break;
                    case State.l:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "l")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.ShortDateCompact(culture), culture));
                        break;
                    case State.ll:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "ll")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.LongDateCompact(culture), culture));
                        break;
                    case State.lll:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "lll")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.LongDateShortTimeCompact(culture),
                                culture));
                        break;
                    case State.llll:
                        if (GlobalizationProvider.Instance.LongDateFormat.ShortTime(culture) != "llll")
                            resultBuilder.Append(Format(dateTime,
                                GlobalizationProvider.Instance.LongDateFormat.FullDateTimeCompact(culture), culture));
                        break;
                    case State.InSingleQuoteLiteral:
                    case State.InDoubleQuoteLiteral:
                    case State.InBrackets:
                    case State.EscapeSequence:
                        foreach (char character in tokenBuffer.ToString()) resultBuilder.Append(character);
                        break;
                }

                tokenBuffer.Clear();
                return newState;
            }); // End ChangeState

            foreach (char character in format)
                switch (state)
                {
                    case State.EscapeSequence:
                        tokenBuffer.Append(character);
                        state = changeState(state, State.None);
                        break;
                    case State.InDoubleQuoteLiteral when character == '\"':
                        state = changeState(state, State.None);
                        break;
                    case State.InDoubleQuoteLiteral:
                        tokenBuffer.Append(character);
                        break;
                    case State.InSingleQuoteLiteral when character == '\'':
                        state = changeState(state, State.None);
                        break;
                    case State.InSingleQuoteLiteral:
                        tokenBuffer.Append(character);
                        break;
                    case State.InBrackets when character == ']':
                        state = changeState(state, State.None);
                        break;
                    case State.InBrackets:
                        tokenBuffer.Append(character);
                        break;
                    default:
                        switch (character)
                        {
                            case 'a':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.a;
                                        break;
                                    default:
                                        state = changeState(state, State.a);
                                        break;
                                }

                                break;
                            case 'A':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.A;
                                        break;
                                    default:
                                        state = changeState(state, State.A);
                                        break;
                                }

                                break;
                            case 'd':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.d;
                                        break;
                                    case State.d:
                                        state = State.dd;
                                        break;
                                    case State.dd:
                                        state = State.ddd;
                                        break;
                                    case State.ddd:
                                        state = State.dddd;
                                        break;
                                    default:
                                        state = changeState(state, State.d);
                                        break;
                                }

                                break;
                            case 'D':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.D;
                                        break;
                                    case State.D:
                                        state = State.DD;
                                        break;
                                    case State.DD:
                                        state = State.DDD;
                                        break;
                                    case State.DDD:
                                        state = State.DDDD;
                                        break;
                                    default:
                                        state = changeState(state, State.D);
                                        break;
                                }

                                break;
                            case 'e':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.e;
                                        break;
                                    default:
                                        state = changeState(state, State.e);
                                        break;
                                }

                                break;
                            case 'E':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.E;
                                        break;
                                    default:
                                        state = changeState(state, State.E);
                                        break;
                                }

                                break;
                            case 'g':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.g;
                                        break;
                                    case State.g:
                                        state = State.gg;
                                        break;
                                    case State.gg:
                                        state = State.ggg;
                                        break;
                                    case State.ggg:
                                        state = State.gggg;
                                        break;
                                    default:
                                        state = changeState(state, State.g);
                                        break;
                                }

                                break;
                            case 'G':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.G;
                                        break;
                                    case State.G:
                                        state = State.GG;
                                        break;
                                    case State.GG:
                                        state = State.GGG;
                                        break;
                                    case State.GGG:
                                        state = State.GGGG;
                                        break;
                                    default:
                                        state = changeState(state, State.G);
                                        break;
                                }

                                break;
                            case 'h':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.h;
                                        break;
                                    case State.h:
                                        state = State.hh;
                                        break;
                                    default:
                                        state = changeState(state, State.h);
                                        break;
                                }

                                break;
                            case 'H':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.H;
                                        break;
                                    case State.H:
                                        state = State.HH;
                                        break;
                                    default:
                                        state = changeState(state, State.H);
                                        break;
                                }

                                break;
                            case 'k':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.k;
                                        break;
                                    case State.k:
                                        state = State.kk;
                                        break;
                                    default:
                                        state = changeState(state, State.k);
                                        break;
                                }

                                break;
                            case 'l':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.l;
                                        break;
                                    case State.l:
                                        state = State.ll;
                                        break;
                                    case State.ll:
                                        state = State.lll;
                                        break;
                                    case State.lll:
                                        state = State.llll;
                                        break;
                                    default:
                                        state = changeState(state, State.l);
                                        break;
                                }

                                break;
                            case 'L':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.L;
                                        break;
                                    case State.L:
                                        state = State.LL;
                                        break;
                                    case State.LL:
                                        state = State.LLL;
                                        break;
                                    case State.LLL:
                                        state = State.LLLL;
                                        break;
                                    default:
                                        state = changeState(state, State.L);
                                        break;
                                }

                                break;
                            case 'm':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.m;
                                        break;
                                    case State.m:
                                        state = State.mm;
                                        break;
                                    default:
                                        state = changeState(state, State.m);
                                        break;
                                }

                                break;
                            case 'M':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.M;
                                        break;
                                    case State.M:
                                        state = State.MM;
                                        break;
                                    case State.MM:
                                        state = State.MMM;
                                        break;
                                    case State.MMM:
                                        state = State.MMMM;
                                        break;
                                    default:
                                        state = changeState(state, State.M);
                                        break;
                                }

                                break;
                            case 'o':
                                switch (state)
                                {
                                    case State.D:
                                        state = State.Do;
                                        break;
                                    case State.DDD:
                                        state = State.DDDo;
                                        break;
                                    case State.d:
                                        state = State.@do;
                                        break;
                                    case State.M:
                                        state = State.Mo;
                                        break;
                                    case State.Q:
                                        state = State.Qo;
                                        break;
                                    case State.w:
                                        state = State.wo;
                                        break;
                                    case State.W:
                                        state = State.Wo;
                                        break;
                                    default:
                                        state = changeState(state, State.None);
                                        resultBuilder.Append(character);
                                        break;
                                }

                                break;
                            case 'Q':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.Q;
                                        break;
                                    default:
                                        state = changeState(state, State.Q);
                                        break;
                                }

                                break;
                            case 's':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.s;
                                        break;
                                    case State.s:
                                        state = State.ss;
                                        break;
                                    default:
                                        state = changeState(state, State.None);
                                        break;
                                }

                                break;
                            case 'S':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.S;
                                        break;
                                    case State.S:
                                        state = State.SS;
                                        break;
                                    case State.SS:
                                        state = State.SSS;
                                        break;
                                    case State.LT:
                                        state = State.LTS;
                                        break;
                                    default:
                                        state = changeState(state, State.S);
                                        break;
                                }

                                break;
                            case 'T':
                                switch (state)
                                {
                                    case State.L:
                                        state = State.LT;
                                        break;
                                    default:
                                        state = changeState(state, State.None);
                                        resultBuilder.Append(character);
                                        break;
                                }

                                break;
                            case 'w':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.w;
                                        break;
                                    case State.w:
                                        state = State.ww;
                                        break;
                                    default:
                                        state = changeState(state, State.w);
                                        break;
                                }

                                break;
                            case 'W':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.W;
                                        break;
                                    case State.W:
                                        state = State.WW;
                                        break;
                                    default:
                                        state = changeState(state, State.W);
                                        break;
                                }

                                break;
                            case 'Y':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.Y;
                                        break;
                                    case State.Y:
                                        state = State.YY;
                                        break;
                                    case State.YY:
                                        state = State.YYY;
                                        break;
                                    case State.YYY:
                                        state = State.YYYY;
                                        break;
                                    default:
                                        state = changeState(state, State.Y);
                                        break;
                                }

                                break;
                            case 'Z':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.Z;
                                        break;
                                    case State.Z:
                                        state = State.ZZ;
                                        break;
                                    default:
                                        state = changeState(state, State.Z);
                                        break;
                                }

                                break;
                            case 'x':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.x;
                                        break;
                                    default:
                                        state = changeState(state, State.x);
                                        break;
                                }

                                break;
                            case 'X':
                                switch (state)
                                {
                                    case State.None:
                                        state = State.X;
                                        break;
                                    default:
                                        state = changeState(state, State.X);
                                        break;
                                }

                                break;
                            case ':':
                                state = changeState(state, State.None);
                                resultBuilder.Append(culture.DateTimeFormat.TimeSeparator);
                                break;
                            case '/':
                                state = changeState(state, State.None);
                                resultBuilder.Append(culture.DateTimeFormat.DateSeparator);
                                break;
                            case '[':
                                state = changeState(state, State.InBrackets);
                                break;
                            case '\"':
                                state = changeState(state, State.InDoubleQuoteLiteral);
                                break;
                            case '\'':
                                state = changeState(state, State.InSingleQuoteLiteral);
                                break;
                            case '%':
                                state = changeState(state, State.None);
                                break;
                            case '\\':
                                state = changeState(state, State.EscapeSequence);
                                break;
                            default:
                                state = changeState(state, State.None);
                                resultBuilder.Append(character);
                                break;
                        }

                        break;
                }

            if (state == State.EscapeSequence || state == State.InDoubleQuoteLiteral ||
                state == State.InSingleQuoteLiteral)
                throw new FormatException("Invalid format string");

            changeState(state, State.None);

            return resultBuilder.ToString();
        }

        private enum State
        {
            None,

            //Invalid,
            InSingleQuoteLiteral,
            InDoubleQuoteLiteral,
            InBrackets,
            EscapeSequence,
            A,
            a,
            D,
            Do,
            DD,
            DDD,
            DDDo,
            DDDD,
            d,
            @do,
            dd,
            ddd,
            dddd,
            E,
            e,
            G,
            GG,
            GGG,
            GGGG,
            g,
            gg,
            ggg,
            gggg,
            H,
            HH,
            h,
            hh,
            k,
            kk,
            L,
            LL,
            LLL,
            LLLL,
            LT,
            LTS,
            l,
            ll,
            lll,
            llll,
            M,
            Mo,
            MM,
            MMM,
            MMMM,
            m,
            mm,
            Q,
            Qo,
            S,
            SS,
            SSS,
            s,
            ss,
            W,
            Wo,
            WW,
            w,
            wo,
            ww,
            Y,
            YY,
            YYY,
            YYYY,
            X,
            x,
            Z,
            ZZ
        }
    }
}