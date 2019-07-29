using System;
using System.Globalization;
using MomentJs.Net.Definitions;
using MomentJs.Net.Formats;
using MomentJs.Net.Formatters;
using NUnit.Framework;

namespace MomentJs.Net.Tests.Formatters
{
    [TestFixture]
    public class DateFormatterTests
    {
        private static readonly DateTime DateTime = new DateTime(1986, 9, 4, 20, 30, 25, 123);

        [TestCase(FormatToken.M, "en-US", ExpectedResult = "9")]
        [TestCase(FormatToken.M, "da-DK", ExpectedResult = "9")]
        [TestCase(FormatToken.Mo, "en-US", ExpectedResult = "9th")]
        [TestCase(FormatToken.Mo, "da-DK", ExpectedResult = "9.")]
        [TestCase(FormatToken.MM, "en-US", ExpectedResult = "09")]
        [TestCase(FormatToken.MM, "da-DK", ExpectedResult = "09")]
        [TestCase(FormatToken.MMM, "en-US", ExpectedResult = "Sep")]
        [TestCase(FormatToken.MMM, "da-DK", ExpectedResult = "sep")]
        [TestCase(FormatToken.MMMM, "en-US", ExpectedResult = "September")]
        [TestCase(FormatToken.MMMM, "da-DK", ExpectedResult = "september")]
        [TestCase(FormatToken.Q, "en-US", ExpectedResult = "3")]
        [TestCase(FormatToken.Q, "da-DK", ExpectedResult = "3")]
        [TestCase(FormatToken.Qo, "en-US", ExpectedResult = "3rd")]
        [TestCase(FormatToken.Qo, "da-DK", ExpectedResult = "3.")]
        [TestCase(FormatToken.D, "en-US", ExpectedResult = "4")]
        [TestCase(FormatToken.D, "da-DK", ExpectedResult = "4")]
        [TestCase(FormatToken.Do, "en-US", ExpectedResult = "4th")]
        [TestCase(FormatToken.Do, "da-DK", ExpectedResult = "4.")]
        [TestCase(FormatToken.DD, "en-US", ExpectedResult = "04")]
        [TestCase(FormatToken.DD, "da-DK", ExpectedResult = "04")]
        [TestCase(FormatToken.DDD, "en-US", ExpectedResult = "247")]
        [TestCase(FormatToken.DDD, "da-DK", ExpectedResult = "247")]
        [TestCase(FormatToken.DDDo, "en-US", ExpectedResult = "247th")]
        [TestCase(FormatToken.DDDo, "da-DK", ExpectedResult = "247.")]
        [TestCase(FormatToken.DDDD, "en-US", ExpectedResult = "247")]
        [TestCase(FormatToken.DDDD, "da-DK", ExpectedResult = "247")]
        [TestCase(FormatToken.d, "en-US", ExpectedResult = "4")]
        [TestCase(FormatToken.d, "da-DK", ExpectedResult = "4")]
        [TestCase(FormatToken.@do, "en-US", ExpectedResult = "4th")]
        [TestCase(FormatToken.@do, "da-DK", ExpectedResult = "4.")]
        [TestCase(FormatToken.dd, "en-US", ExpectedResult = "Th")]
        [TestCase(FormatToken.dd, "da-DK", ExpectedResult = "to")]
        [TestCase(FormatToken.ddd, "en-US", ExpectedResult = "Thu")]
        [TestCase(FormatToken.ddd, "da-DK", ExpectedResult = "to")]
        [TestCase(FormatToken.dddd, "en-US", ExpectedResult = "Thursday")]
        [TestCase(FormatToken.dddd, "da-DK", ExpectedResult = "torsdag")]
        [TestCase(FormatToken.e, "en-US", ExpectedResult = "4")]
        [TestCase(FormatToken.e, "da-DK", ExpectedResult = "4")]
        [TestCase(FormatToken.E, "en-US", ExpectedResult = "4")]
        [TestCase(FormatToken.E, "da-DK", ExpectedResult = "3")]
        [TestCase(FormatToken.w, "en-US", ExpectedResult = "36")]
        [TestCase(FormatToken.w, "da-DK", ExpectedResult = "36")]
        [TestCase(FormatToken.wo, "en-US", ExpectedResult = "36th")]
        [TestCase(FormatToken.wo, "da-DK", ExpectedResult = "36.")]
        [TestCase(FormatToken.ww, "en-US", ExpectedResult = "36")]
        [TestCase(FormatToken.ww, "da-DK", ExpectedResult = "36")]
        [TestCase(FormatToken.W, "en-US", ExpectedResult = "36")]
        [TestCase(FormatToken.W, "da-DK", ExpectedResult = "36")]
        [TestCase(FormatToken.Wo, "en-US", ExpectedResult = "36th")]
        [TestCase(FormatToken.Wo, "da-DK", ExpectedResult = "36.")]
        [TestCase(FormatToken.WW, "en-US", ExpectedResult = "36")]
        [TestCase(FormatToken.WW, "da-DK", ExpectedResult = "36")]
        [TestCase(FormatToken.YY, "en-US", ExpectedResult = "86")]
        [TestCase(FormatToken.YY, "da-DK", ExpectedResult = "86")]
        [TestCase(FormatToken.YYYY, "en-US", ExpectedResult = "1986")]
        [TestCase(FormatToken.YYYY, "da-DK", ExpectedResult = "1986")]
        [TestCase(FormatToken.Y, "en-US", ExpectedResult = "1986")]
        [TestCase(FormatToken.Y, "da-DK", ExpectedResult = "1986")]
        [TestCase(FormatToken.gg, "en-US", ExpectedResult = "86")]
        [TestCase(FormatToken.gg, "da-DK", ExpectedResult = "86")]
        [TestCase(FormatToken.GG, "en-US", ExpectedResult = "86")]
        [TestCase(FormatToken.GG, "da-DK", ExpectedResult = "86")]
        [TestCase(FormatToken.A, "en-US", ExpectedResult = "PM")]
        [TestCase(FormatToken.A, "da-DK", ExpectedResult = "")]
        [TestCase(FormatToken.a, "en-US", ExpectedResult = "pm")]
        [TestCase(FormatToken.a, "da-DK", ExpectedResult = "")]
        [TestCase(FormatToken.H, "en-US", ExpectedResult = "20")]
        [TestCase(FormatToken.H, "da-DK", ExpectedResult = "20")]
        [TestCase(FormatToken.HH, "en-US", ExpectedResult = "20")]
        [TestCase(FormatToken.HH, "da-DK", ExpectedResult = "20")]
        [TestCase(FormatToken.h, "en-US", ExpectedResult = "8")]
        [TestCase(FormatToken.h, "da-DK", ExpectedResult = "8")]
        [TestCase(FormatToken.hh, "en-US", ExpectedResult = "08")]
        [TestCase(FormatToken.hh, "da-DK", ExpectedResult = "08")]
        [TestCase(FormatToken.k, "en-US", ExpectedResult = "21")]
        [TestCase(FormatToken.k, "da-DK", ExpectedResult = "21")]
        [TestCase(FormatToken.kk, "en-US", ExpectedResult = "21")]
        [TestCase(FormatToken.kk, "da-DK", ExpectedResult = "21")]
        [TestCase(FormatToken.m, "en-US", ExpectedResult = "30")]
        [TestCase(FormatToken.m, "da-DK", ExpectedResult = "30")]
        [TestCase(FormatToken.mm, "en-US", ExpectedResult = "30")]
        [TestCase(FormatToken.mm, "da-DK", ExpectedResult = "30")]
        [TestCase(FormatToken.s, "en-US", ExpectedResult = "25")]
        [TestCase(FormatToken.s, "da-DK", ExpectedResult = "25")]
        [TestCase(FormatToken.ss, "en-US", ExpectedResult = "25")]
        [TestCase(FormatToken.ss, "da-DK", ExpectedResult = "25")]
        [TestCase(FormatToken.S, "en-US", ExpectedResult = "1")]
        [TestCase(FormatToken.S, "da-DK", ExpectedResult = "1")]
        [TestCase(FormatToken.SS, "en-US", ExpectedResult = "12")]
        [TestCase(FormatToken.SS, "da-DK", ExpectedResult = "12")]
        [TestCase(FormatToken.SSS, "en-US", ExpectedResult = "123")]
        [TestCase(FormatToken.SSS, "da-DK", ExpectedResult = "123")]
        [TestCase(FormatToken.SSSS, "en-US", ExpectedResult = "")]
        [TestCase(FormatToken.SSSS, "da-DK", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSS, "en-US", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSSS, "en-US", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSSSS, "en-US", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSSSSS, "en-US", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSSSSSS, "en-US", ExpectedResult = "")]
        [TestCase(FormatToken.SSSSSSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(FormatToken.Z, "en-US", ExpectedResult = "+02:00")]
        [TestCase(FormatToken.Z, "da-DK", ExpectedResult = "+02:00")]
        [TestCase(FormatToken.ZZ, "en-US", ExpectedResult = "+0200")]
        [TestCase(FormatToken.ZZ, "da-DK", ExpectedResult = "+0200")]
        [TestCase(FormatToken.X, "en-US", ExpectedResult = "526242625")]
        [TestCase(FormatToken.X, "da-DK", ExpectedResult = "526242625")]
        [TestCase(FormatToken.x, "en-US", ExpectedResult = "526242625123")]
        [TestCase(FormatToken.x, "da-DK", ExpectedResult = "526242625123")]
        public string StandardFormat_With_StandardLocaleDefinition(FormatToken formatToken, string cultureName)
        {
            // Arrange
            LocaleDefinition localeDefinition = GetLocaleDefinition();
            CultureInfo culture = new CultureInfo(cultureName);

            // Act
            string result = MomentFormatter.Format(DateTime, formatToken, localeDefinition, culture);

            // Assert
            return result;
        }

        [TestCase("dddd, MMMM D, YYYY h:mm A", "en-US", ExpectedResult = "Thursday, September 4, 1986 8:30 PM")]
        [TestCase("dddd, Do MMMM, YYYY HH:mm", "da-DK", ExpectedResult = "torsdag, 4. september, 1986 20:30")]
        [TestCase("dddd, Do MMMM, YYYY 'YYYY' HH:mm", "da-DK", ExpectedResult =
            "torsdag, 4. september, 1986 YYYY 20:30")]
        public string CustomFormat_With_LocaleDefinition(string format, string cultureName)
        {
            // Arrange
            LocaleDefinition localeDefinition = GetLocaleDefinition();
            CultureInfo culture = new CultureInfo(cultureName);

            // Act
            string result = MomentFormatter.Format(DateTime, format, localeDefinition, culture);

            // Assert
            return result;
        }

        private static LocaleDefinition GetLocaleDefinition()
        {
            LocaleDefinition localeDefinition = new LocaleDefinition
            {
                Ordinal = culture =>
                {
                    switch (culture.Name)
                    {
                        case "en-US":
                            return @"function (number) { var b = number % 10,
                output = (~~(number % 100 / 10) === 1) ? 'th' :
                (b === 1) ? 'st' :
                (b === 2) ? 'nd' :
                (b === 3) ? 'rd' : 'th';
                console.log(output);
            return number + output; }";
                        case "da-DK":
                            return @"function (number){return number+'.';}";
                        default:
                            return @"function (number){return number;}";
                    }
                }
            };


            return localeDefinition;
        }
    }
}