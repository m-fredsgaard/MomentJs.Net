using System;
using System.Text;
using MomentJs.Net.Definitions;
using MomentJs.Net.Exceptions;
using MomentJs.Net.Formats;

namespace MomentJs.Net.Formatters
{
    public static class MomentFormatter
    {
        public static string Format(DateTime dateTime, MomentFormat format, LocaleDefinition locale)
        {
            return Format(dateTime, format.ToString(), locale);
        }

        public static string Format(DateTime dateTime, string format, LocaleDefinition locale)
        {
            if (format == null)
                return null;

            StringBuilder result = new StringBuilder();

            State state = State.None;
            StringBuilder tokenBuffer = new StringBuilder();

            var changeState = new Func<State, State, State>((currentState, newState) =>
            {
                switch (currentState)
                {
                    case State.M:
                        result.Append(dateTime.Month);
                        break;
                    case State.Mo:
                        result.Append(locale.Ordinal.Format(dateTime.Month));
                        break;
                    case State.MM:
                        result.Append(dateTime.Month.ToString().PadLeft(2, '0'));
                        break;
                    case State.MMM:
                        result.Append(locale.MonthsShort[dateTime.Month - 1]);
                        break;
                    case State.MMMM:
                        result.Append(locale.Months[dateTime.Month - 1]);
                        break;
                    case State.Q:
                        result.Append((int) Math.Ceiling(dateTime.Month / 3.0));
                        break;
                    case State.Qo:
                        result.Append(locale.Ordinal.Format((int) Math.Ceiling(dateTime.Month / 3.0)));
                        break;
                    case State.D:
                        result.Append(dateTime.Day);
                        break;
                    case State.Do:
                        result.Append(locale.Ordinal.Format(dateTime.Day));
                        break;
                    case State.DD:
                        result.Append(dateTime.Day.ToString().PadLeft(2, '0'));
                        break;
                    case State.DDD:
                        result.Append(dateTime.DayOfYear);
                        break;
                    case State.DDDo:
                        result.Append(locale.Ordinal.Format(dateTime.DayOfYear));
                        break;
                    case State.DDDD:
                        result.Append(dateTime.DayOfYear.ToString().PadLeft(3, '0'));
                        break;
                    case State.d:
                        result.Append((int) dateTime.DayOfWeek);
                        break;
                    case State.@do:
                        result.Append(locale.Ordinal.Format((int) dateTime.DayOfWeek));
                        break;
                    case State.dd:
                        result.Append(locale.WeekdaysMin[(int) dateTime.DayOfWeek]);
                        break;
                    case State.ddd:
                        result.Append(locale.WeekdaysShort[(int) dateTime.DayOfWeek]);
                        break;
                    case State.dddd:
                        result.Append(locale.Weekdays[(int) dateTime.DayOfWeek]);
                        break;
                    case State.e:
                        result.Append((int) dateTime.DayOfWeek);
                        break;
                    case State.E:
                        int dayOfWeek = (int) dateTime.DayOfWeek - (int) locale.Culture.DateTimeFormat.FirstDayOfWeek;
                        if (dayOfWeek < 0)
                            dayOfWeek = 7 + dayOfWeek;
                        result.Append(dayOfWeek);
                        break;
                    case State.w:
                    case State.W:
                        result.Append(locale.Culture.Calendar.GetWeekOfYear(dateTime,
                            locale.Culture.DateTimeFormat.CalendarWeekRule,
                            locale.Culture.DateTimeFormat.FirstDayOfWeek));
                        break;
                    case State.wo:
                    case State.Wo:
                        result.Append(locale.Ordinal.Format(locale.Culture.Calendar.GetWeekOfYear(dateTime,
                            locale.Culture.DateTimeFormat.CalendarWeekRule,
                            locale.Culture.DateTimeFormat.FirstDayOfWeek)));
                        break;
                    case State.ww:
                    case State.WW:
                        result.Append(locale.Culture.Calendar.GetWeekOfYear(dateTime,
                            locale.Culture.DateTimeFormat.CalendarWeekRule,
                            locale.Culture.DateTimeFormat.FirstDayOfWeek).ToString().PadLeft(2, '0'));
                        break;
                    case State.Y:
                        result.Append(dateTime.Year.ToString());
                        break;
                    case State.YY:
                        result.Append(dateTime.Year.ToString().Substring(2));
                        break;
                    case State.YYYY:
                        if (dateTime.Year > 9999)
                            throw new UnsupportedFormatException(
                                "The YYYY format doesn't support years above 9999. Use Y instead.");
                        result.Append(dateTime.Year.ToString());
                        break;
                    case State.gg:
                        result.Append(dateTime.Year.ToString().Substring(2));
                        break;
                    case State.gggg:
                        if (dateTime.Year > 9999)
                            throw new UnsupportedFormatException(
                                "The gggg format doesn't support years above 9999. Use Y instead.");
                        result.Append(dateTime.Year.ToString());
                        break;
                    case State.GG:
                        result.Append(dateTime.Year.ToString().Substring(2));
                        break;
                    case State.GGGG:
                        if (dateTime.Year > 9999)
                            throw new UnsupportedFormatException(
                                "The gggg format doesn't support years above 9999. Use Y instead.");
                        result.Append(dateTime.Year.ToString());
                        break;
                    case State.A:
                        result.Append(dateTime.TimeOfDay >= TimeSpan.Zero && dateTime.TimeOfDay < TimeSpan.FromHours(12)
                            ? locale.Culture.DateTimeFormat.AMDesignator.ToUpper()
                            : locale.Culture.DateTimeFormat.PMDesignator.ToUpper());
                        break;
                    case State.a:
                        result.Append(dateTime.TimeOfDay >= TimeSpan.Zero && dateTime.TimeOfDay < TimeSpan.FromHours(12)
                            ? locale.Culture.DateTimeFormat.AMDesignator.ToLower()
                            : locale.Culture.DateTimeFormat.PMDesignator.ToLower());
                        break;
                    case State.H:
                        result.Append(dateTime.Hour);
                        break;
                    case State.HH:
                        result.Append(dateTime.Hour.ToString().PadLeft(2, '0'));
                        break;
                    case State.h:
                        int h = dateTime.TimeOfDay < TimeSpan.FromHours(12)
                            ? dateTime.Hour
                            : dateTime.Hour - 12;
                        result.Append(h);
                        break;
                    case State.hh:
                        int hh = dateTime.TimeOfDay < TimeSpan.FromHours(12)
                            ? dateTime.Hour
                            : dateTime.Hour - 12;
                        result.Append(hh.ToString().PadLeft(2, '0'));
                        break;
                    case State.k:
                        result.Append(dateTime.Hour + 1);
                        break;
                    case State.kk:
                        result.Append((dateTime.Hour + 1).ToString().PadLeft(2, '0'));
                        break;
                    case State.m:
                        result.Append(dateTime.Minute);
                        break;
                    case State.mm:
                        result.Append(dateTime.Minute.ToString().PadLeft(2, '0'));
                        break;
                    case State.s:
                        result.Append(dateTime.Second);
                        break;
                    case State.ss:
                        result.Append(dateTime.Second.ToString().PadLeft(2, '0'));
                        break;
                    case State.S:
                        string valueS = dateTime.Millisecond.ToString();
                        result.Append(valueS.Substring(0, Math.Min(valueS.Length, 1)).PadLeft(1, '0'));
                        break;
                    case State.SS:
                        string upperS2 = dateTime.Millisecond.ToString();
                        result.Append(upperS2.Substring(0, Math.Min(upperS2.Length, 2)).PadLeft(2, '0'));
                        break;
                    case State.SSS:
                        string upperS3 = dateTime.Millisecond.ToString();
                        result.Append(upperS3.Substring(0, Math.Min(upperS3.Length, 3)).PadLeft(3, '0'));
                        break;
                    case State.Z:
                        TimeSpan upperZ = new DateTimeOffset(dateTime).Offset;
                        result.Append(upperZ < TimeSpan.Zero ? "-" : "+");
                        result.Append($"{upperZ.Hours.ToString().PadLeft(2, '0')}:00");
                        break;
                    case State.ZZ:
                        TimeSpan upperZ2 = new DateTimeOffset(dateTime).Offset;
                        result.Append(upperZ2 < TimeSpan.Zero ? "-" : "+");
                        result.Append($"{upperZ2.Hours.ToString().PadLeft(2, '0')}00");
                        break;
                    case State.X:
                        DateTimeOffset upperX = new DateTimeOffset(dateTime);
                        result.Append(upperX.ToUnixTimeSeconds());
                        break;
                    case State.x:
                        DateTimeOffset x = new DateTimeOffset(dateTime);
                        result.Append(x.ToUnixTimeMilliseconds());
                        break;
                    case State.LT:
                        result.Append(Format(dateTime, locale.LongDateFormat.LT, locale));
                        break;
                    case State.LTS:
                        result.Append(Format(dateTime, locale.LongDateFormat.LTS, locale));
                        break;
                    case State.L:
                        result.Append(Format(dateTime, locale.LongDateFormat.L, locale));
                        break;
                    case State.LL:
                        result.Append(Format(dateTime, locale.LongDateFormat.LL, locale));
                        break;
                    case State.LLL:
                        result.Append(Format(dateTime, locale.LongDateFormat.LLL, locale));
                        break;
                    case State.LLLL:
                        result.Append(Format(dateTime, locale.LongDateFormat.LLLL, locale));
                        break;
                    case State.l:
                        result.Append(Format(dateTime, locale.LongDateFormat.l, locale));
                        break;
                    case State.ll:
                        result.Append(Format(dateTime, locale.LongDateFormat.ll, locale));
                        break;
                    case State.lll:
                        result.Append(Format(dateTime, locale.LongDateFormat.lll, locale));
                        break;
                    case State.llll:
                        result.Append(Format(dateTime, locale.LongDateFormat.llll, locale));
                        break;
                    case State.InSingleQuoteLiteral:
                    case State.InDoubleQuoteLiteral:
                    case State.EscapeSequence:
                        foreach (char character in tokenBuffer.ToString()) result.Append(character);
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
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
                                        state = State.Invalid;
                                        break;
                                }

                                break;
                            case ':':
                                state = changeState(state, State.None);
                                result.Append(locale.Culture.DateTimeFormat.TimeSeparator);
                                break;
                            case '/':
                                state = changeState(state, State.None);
                                result.Append(locale.Culture.DateTimeFormat.DateSeparator);
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
                                result.Append(character);
                                break;
                        }

                        break;
                }

            if (state == State.EscapeSequence || state == State.InDoubleQuoteLiteral ||
                state == State.InSingleQuoteLiteral)
                throw new FormatException("Invalid format string");

            changeState(state, State.None);

            return result.ToString();
        }

        private enum State
        {
            None,
            Invalid,
            InSingleQuoteLiteral,
            InDoubleQuoteLiteral,
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