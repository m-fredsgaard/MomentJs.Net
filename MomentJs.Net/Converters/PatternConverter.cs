using System;
using System.Text;
using MomentJs.Net.Definitions;
using MomentJs.Net.Exceptions;
using MomentJs.Net.Formats;

namespace MomentJs.Net.Converters
{
    public class PatternConverter
    {
        public static string ConvertToMomentPattern(string standardPattern, LocaleDefinition locale,
            MomentFormat format, bool tolerant = true)
        {
            StringBuilder result = new StringBuilder();

            State state = State.None;
            StringBuilder tokenBuffer = new StringBuilder();

            var changeState = new Func<State, State, State>((currentState, newState) =>
            {
                switch (currentState)
                {
                    case State.d when format != MomentFormat.L:
                    case State.dd when format == MomentFormat.l:
                        result.Append("D");
                        break;
                    case State.d when format == MomentFormat.L:
                    case State.dd:
                        result.Append("DD");
                        break;
                    case State.ddd:
                    case State.dddd when format == MomentFormat.ll:
                    case State.dddd when format == MomentFormat.lll:
                    case State.dddd when format == MomentFormat.llll:
                        result.Append("ddd");
                        break;
                    case State.dddd:
                        result.Append("dddd");
                        break;
                    case State.f:
                    case State.F:
                        result.Append("S");
                        break;
                    case State.ff:
                    case State.FF:
                        result.Append("SS");
                        break;
                    case State.fff:
                    case State.FFF:
                        result.Append("SSS");
                        break;
                    case State.ffff:
                    case State.FFFF:
                        result.Append("SSSS");
                        break;
                    case State.fffff:
                    case State.FFFFF:
                        result.Append("SSSSS");
                        break;
                    case State.ffffff:
                    case State.FFFFFF:
                        result.Append("SSSSSS");
                        break;
                    case State.fffffff:
                    case State.FFFFFFF:
                        result.Append("SSSSSSS");
                        break;
                    case State.g:
                        throw new UnsupportedFormatException("Era not supported in MomentJS");
                    case State.h:
                        result.Append("h");
                        break;
                    case State.hh:
                        result.Append("hh");
                        break;
                    case State.H:
                        result.Append("H");
                        break;
                    case State.HH:
                        result.Append("HH");
                        break;
                    case State.m:
                        result.Append("m");
                        break;
                    case State.mm:
                        result.Append("mm");
                        break;
                    case State.M when format != MomentFormat.L:
                    case State.MM when format == MomentFormat.l:
                        result.Append("M");
                        break;
                    case State.M when format == MomentFormat.L:
                    case State.MM:
                        result.Append("MM");
                        break;
                    case State.MMM:
                    case State.MMMM when format == MomentFormat.ll:
                    case State.MMMM when format == MomentFormat.lll:
                    case State.MMMM when format == MomentFormat.llll:
                        result.Append("MMM");
                        break;
                    case State.MMMM:
                        result.Append("MMMM");
                        break;
                    case State.s:
                        result.Append("s");
                        break;
                    case State.ss:
                        result.Append("ss");
                        break;
                    case State.t:
                        if (tolerant)
                            result.Append("A");
                        else
                            throw new UnsupportedFormatException("Single Letter AM/PM not supported in MomentJS");
                        break;
                    case State.tt:
                        result.Append("A");
                        break;
                    case State.y:
                        if (tolerant)
                            result.Append("YY");
                        else
                            throw new UnsupportedFormatException("Single Letter Year not supported in MomentJS");
                        break;
                    case State.yy:
                        result.Append("YY");
                        break;
                    case State.yyy:
                        if (tolerant)
                            result.Append("YYYY");
                        else
                            throw new UnsupportedFormatException("Three Letter Year not supported in MomentJS");
                        break;
                    case State.yyyy:
                        result.Append("YYYY");
                        break;
                    case State.yyyyy:
                        if (tolerant)
                            result.Append("Y");
                        else
                            throw new UnsupportedFormatException("Five or more Letter Year not supported in MomentJS");
                        break;
                    case State.z:
                    case State.zz:
                        if (tolerant)
                            result.Append("ZZ");
                        else
                            throw new UnsupportedFormatException("Hours offset not supported in MomentJS");
                        break;
                    case State.zzz:
                        result.Append("Z");
                        break;
                    case State.InSingleQuoteLiteral:
                    case State.InDoubleQuoteLiteral:
                    case State.EscapeSequence:
                        foreach (char lCharacter in tokenBuffer.ToString()) result.Append(lCharacter);
                        break;
                }

                tokenBuffer.Clear();
                return newState;
            }); // End ChangeState

            foreach (char character in standardPattern)
                if (state == State.EscapeSequence)
                {
                    tokenBuffer.Append(character);
                    state = changeState(state, State.None);
                }
                else if (state == State.InDoubleQuoteLiteral)
                {
                    if (character == '\"')
                        state = changeState(state, State.None);
                    else
                        tokenBuffer.Append(character);
                }
                else if (state == State.InSingleQuoteLiteral)
                {
                    if (character == '\'')
                        state = changeState(state, State.None);
                    else
                        tokenBuffer.Append(character);
                }
                else
                {
                    switch (character)
                    {
                        case 'd':
                            switch (state)
                            {
                                case State.d:
                                    state = State.dd;
                                    break;
                                case State.dd:
                                    state = State.ddd;
                                    break;
                                case State.ddd:
                                    state = State.dddd;
                                    break;
                                case State.dddd:
                                    break;
                                default:
                                    state = changeState(state, State.d);
                                    break;
                            }

                            break;
                        case 'f':
                            switch (state)
                            {
                                case State.f:
                                    state = State.ff;
                                    break;
                                case State.ff:
                                    state = State.fff;
                                    break;
                                case State.fff:
                                    state = State.ffff;
                                    break;
                                case State.ffff:
                                    state = State.fffff;
                                    break;
                                case State.fffff:
                                    state = State.ffffff;
                                    break;
                                case State.ffffff:
                                    state = State.fffffff;
                                    break;
                                case State.fffffff:
                                    break;
                                default:
                                    state = changeState(state, State.f);
                                    break;
                            }

                            break;
                        case 'F':
                            switch (state)
                            {
                                case State.F:
                                    state = State.FF;
                                    break;
                                case State.FF:
                                    state = State.FFF;
                                    break;
                                case State.FFF:
                                    state = State.FFFF;
                                    break;
                                case State.FFFF:
                                    state = State.FFFFF;
                                    break;
                                case State.FFFFF:
                                    state = State.FFFFFF;
                                    break;
                                case State.FFFFFF:
                                    state = State.FFFFFFF;
                                    break;
                                case State.FFFFFFF:
                                    break;
                                default:
                                    state = changeState(state, State.F);
                                    break;
                            }

                            break;
                        case 'g':
                            switch (state)
                            {
                                case State.g:
                                    break;
                                default:
                                    state = changeState(state, State.g);
                                    break;
                            }

                            break;
                        case 'h':
                            switch (state)
                            {
                                case State.h:
                                    state = State.hh;
                                    break;
                                case State.hh:
                                    break;
                                default:
                                    state = changeState(state, State.h);
                                    break;
                            }

                            break;
                        case 'H':
                            switch (state)
                            {
                                case State.H:
                                    state = State.HH;
                                    break;
                                case State.HH:
                                    break;
                                default:
                                    state = changeState(state, State.H);
                                    break;
                            }

                            break;
                        case 'K':
                            state = changeState(state, State.None);
                            if (tolerant)
                                result.Append("Z");
                            else
                                throw new UnsupportedFormatException("TimeZoneInformation not supported in MomentJS");
                            break;
                        case 'm':
                            switch (state)
                            {
                                case State.m:
                                    state = State.mm;
                                    break;
                                case State.mm:
                                    break;
                                default:
                                    state = changeState(state, State.m);
                                    break;
                            }

                            break;
                        case 'M':
                            switch (state)
                            {
                                case State.M:
                                    state = State.MM;
                                    break;
                                case State.MM:
                                    state = State.MMM;
                                    break;
                                case State.MMM:
                                    state = State.MMMM;
                                    break;
                                case State.MMMM:
                                    break;
                                default:
                                    state = changeState(state, State.M);
                                    break;
                            }

                            break;
                        case 's':
                            switch (state)
                            {
                                case State.s:
                                    state = State.ss;
                                    break;
                                case State.ss:
                                    break;
                                default:
                                    state = changeState(state, State.s);
                                    break;
                            }

                            break;
                        case 't':
                            switch (state)
                            {
                                case State.t:
                                    state = State.tt;
                                    break;
                                case State.tt:
                                    break;
                                default:
                                    state = changeState(state, State.t);
                                    break;
                            }

                            break;
                        case 'y':
                            switch (state)
                            {
                                case State.y:
                                    state = State.yy;
                                    break;
                                case State.yy:
                                    state = State.yyy;
                                    break;
                                case State.yyy:
                                    state = State.yyyy;
                                    break;
                                case State.yyyy:
                                    state = State.yyyyy;
                                    break;
                                case State.yyyyy:
                                    break;
                                default:
                                    state = changeState(state, State.y);
                                    break;
                            }

                            break;
                        case 'z':
                            switch (state)
                            {
                                case State.z:
                                    state = State.zz;
                                    break;
                                case State.zz:
                                    state = State.zzz;
                                    break;
                                case State.zzz:
                                    break;
                                default:
                                    state = changeState(state, State.z);
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
                }

            if (state == State.EscapeSequence || state == State.InDoubleQuoteLiteral ||
                state == State.InSingleQuoteLiteral) throw new FormatException("Invalid Format String");

            changeState(state, State.None);

            return result.ToString();
        }

        private enum State
        {
            None,
            d,
            dd,
            ddd,
            dddd,
            f,
            ff,
            fff,
            ffff,
            fffff,
            ffffff,
            fffffff,
            F,
            FF,
            FFF,
            FFFF,
            FFFFF,
            FFFFFF,
            FFFFFFF,
            g,
            h,
            hh,
            H,
            HH,
            m,
            mm,
            M,
            MM,
            MMM,
            MMMM,
            s,
            ss,
            t,
            tt,
            y,
            yy,
            yyy,
            yyyy,
            yyyyy,
            z,
            zz,
            zzz,
            InSingleQuoteLiteral,
            InDoubleQuoteLiteral,
            EscapeSequence
        }
    }
}