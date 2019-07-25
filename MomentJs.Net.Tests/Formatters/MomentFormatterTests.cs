using System;
using Moment.Net.Formats;
using Moment.Net.Formatters;
using NUnit.Framework;

namespace Moment.Net.Tests.Formatters
{
    [TestFixture]
    public class MomentFormatterTests
    {
        private static readonly DateTime DateTime = new DateTime(1986, 9, 4, 20, 30, 25, 123);

        [TestCase(MomentFormat.M, "en-US", ExpectedResult = "9")]
        [TestCase(MomentFormat.M, "da-DK", ExpectedResult = "9")]
        [TestCase(MomentFormat.Mo, "en-US", ExpectedResult = "9th")]
        [TestCase(MomentFormat.Mo, "da-DK", ExpectedResult = "9.")]
        [TestCase(MomentFormat.MM, "en-US", ExpectedResult = "09")]
        [TestCase(MomentFormat.MM, "da-DK", ExpectedResult = "09")]
        [TestCase(MomentFormat.MMM, "en-US", ExpectedResult = "Sep")]
        [TestCase(MomentFormat.MMM, "da-DK", ExpectedResult = "sep")]
        [TestCase(MomentFormat.MMMM, "en-US", ExpectedResult = "September")]
        [TestCase(MomentFormat.MMMM, "da-DK", ExpectedResult = "september")]
        [TestCase(MomentFormat.Q, "en-US", ExpectedResult = "3")]
        [TestCase(MomentFormat.Q, "da-DK", ExpectedResult = "3")]
        [TestCase(MomentFormat.Qo, "en-US", ExpectedResult = "3rd")]
        [TestCase(MomentFormat.Qo, "da-DK", ExpectedResult = "3.")]
        [TestCase(MomentFormat.D, "en-US", ExpectedResult = "4")]
        [TestCase(MomentFormat.D, "da-DK", ExpectedResult = "4")]
        [TestCase(MomentFormat.Do, "en-US", ExpectedResult = "4th")]
        [TestCase(MomentFormat.Do, "da-DK", ExpectedResult = "4.")]
        [TestCase(MomentFormat.DD, "en-US", ExpectedResult = "04")]
        [TestCase(MomentFormat.DD, "da-DK", ExpectedResult = "04")]
        [TestCase(MomentFormat.DDD, "en-US", ExpectedResult = "247")]
        [TestCase(MomentFormat.DDD, "da-DK", ExpectedResult = "247")]
        [TestCase(MomentFormat.DDDo, "en-US", ExpectedResult = "247th")]
        [TestCase(MomentFormat.DDDo, "da-DK", ExpectedResult = "247.")]
        [TestCase(MomentFormat.DDDD, "en-US", ExpectedResult = "247")]
        [TestCase(MomentFormat.DDDD, "da-DK", ExpectedResult = "247")]
        [TestCase(MomentFormat.d, "en-US", ExpectedResult = "4")]
        [TestCase(MomentFormat.d, "da-DK", ExpectedResult = "4")]
        [TestCase(MomentFormat.@do, "en-US", ExpectedResult = "4th")]
        [TestCase(MomentFormat.@do, "da-DK", ExpectedResult = "4.")]
        [TestCase(MomentFormat.dd, "en-US", ExpectedResult = "Th")]
        [TestCase(MomentFormat.dd, "da-DK", ExpectedResult = "to")]
        [TestCase(MomentFormat.ddd, "en-US", ExpectedResult = "Thu")]
        [TestCase(MomentFormat.ddd, "da-DK", ExpectedResult = "to")]
        [TestCase(MomentFormat.dddd, "en-US", ExpectedResult = "Thursday")]
        [TestCase(MomentFormat.dddd, "da-DK", ExpectedResult = "torsdag")]
        [TestCase(MomentFormat.e, "en-US", ExpectedResult = "4")]
        [TestCase(MomentFormat.e, "da-DK", ExpectedResult = "4")]
        [TestCase(MomentFormat.E, "en-US", ExpectedResult = "4")]
        [TestCase(MomentFormat.E, "da-DK", ExpectedResult = "3")]
        [TestCase(MomentFormat.w, "en-US", ExpectedResult = "36")]
        [TestCase(MomentFormat.w, "da-DK", ExpectedResult = "36")]
        [TestCase(MomentFormat.wo, "en-US", ExpectedResult = "36th")]
        [TestCase(MomentFormat.wo, "da-DK", ExpectedResult = "36.")]
        [TestCase(MomentFormat.ww, "en-US", ExpectedResult = "36")]
        [TestCase(MomentFormat.ww, "da-DK", ExpectedResult = "36")]
        [TestCase(MomentFormat.W, "en-US", ExpectedResult = "36")]
        [TestCase(MomentFormat.W, "da-DK", ExpectedResult = "36")]
        [TestCase(MomentFormat.Wo, "en-US", ExpectedResult = "36th")]
        [TestCase(MomentFormat.Wo, "da-DK", ExpectedResult = "36.")]
        [TestCase(MomentFormat.WW, "en-US", ExpectedResult = "36")]
        [TestCase(MomentFormat.WW, "da-DK", ExpectedResult = "36")]
        [TestCase(MomentFormat.YY, "en-US", ExpectedResult = "86")]
        [TestCase(MomentFormat.YY, "da-DK", ExpectedResult = "86")]
        [TestCase(MomentFormat.YYYY, "en-US", ExpectedResult = "1986")]
        [TestCase(MomentFormat.YYYY, "da-DK", ExpectedResult = "1986")]
        [TestCase(MomentFormat.Y, "en-US", ExpectedResult = "1986")]
        [TestCase(MomentFormat.Y, "da-DK", ExpectedResult = "1986")]
        [TestCase(MomentFormat.gg, "en-US", ExpectedResult = "86")]
        [TestCase(MomentFormat.gg, "da-DK", ExpectedResult = "86")]
        [TestCase(MomentFormat.GG, "en-US", ExpectedResult = "86")]
        [TestCase(MomentFormat.GG, "da-DK", ExpectedResult = "86")]
        [TestCase(MomentFormat.A, "en-US", ExpectedResult = "PM")]
        [TestCase(MomentFormat.A, "da-DK", ExpectedResult = "")]
        [TestCase(MomentFormat.a, "en-US", ExpectedResult = "pm")]
        [TestCase(MomentFormat.a, "da-DK", ExpectedResult = "")]
        [TestCase(MomentFormat.H, "en-US", ExpectedResult = "20")]
        [TestCase(MomentFormat.H, "da-DK", ExpectedResult = "20")]
        [TestCase(MomentFormat.HH, "en-US", ExpectedResult = "20")]
        [TestCase(MomentFormat.HH, "da-DK", ExpectedResult = "20")]
        [TestCase(MomentFormat.h, "en-US", ExpectedResult = "8")]
        [TestCase(MomentFormat.h, "da-DK", ExpectedResult = "8")]
        [TestCase(MomentFormat.hh, "en-US", ExpectedResult = "08")]
        [TestCase(MomentFormat.hh, "da-DK", ExpectedResult = "08")]
        [TestCase(MomentFormat.k, "en-US", ExpectedResult = "21")]
        [TestCase(MomentFormat.k, "da-DK", ExpectedResult = "21")]
        [TestCase(MomentFormat.kk, "en-US", ExpectedResult = "21")]
        [TestCase(MomentFormat.kk, "da-DK", ExpectedResult = "21")]
        [TestCase(MomentFormat.m, "en-US", ExpectedResult = "30")]
        [TestCase(MomentFormat.m, "da-DK", ExpectedResult = "30")]
        [TestCase(MomentFormat.mm, "en-US", ExpectedResult = "30")]
        [TestCase(MomentFormat.mm, "da-DK", ExpectedResult = "30")]
        [TestCase(MomentFormat.s, "en-US", ExpectedResult = "25")]
        [TestCase(MomentFormat.s, "da-DK", ExpectedResult = "25")]
        [TestCase(MomentFormat.ss, "en-US", ExpectedResult = "25")]
        [TestCase(MomentFormat.ss, "da-DK", ExpectedResult = "25")]
        [TestCase(MomentFormat.S, "en-US", ExpectedResult = "1")]
        [TestCase(MomentFormat.S, "da-DK", ExpectedResult = "1")]
        [TestCase(MomentFormat.SS, "en-US", ExpectedResult = "12")]
        [TestCase(MomentFormat.SS, "da-DK", ExpectedResult = "12")]
        [TestCase(MomentFormat.SSS, "en-US", ExpectedResult = "123")]
        [TestCase(MomentFormat.SSS, "da-DK", ExpectedResult = "123")]
        [TestCase(MomentFormat.SSSS, "en-US", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSS, "da-DK", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSS, "en-US", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSSS, "en-US", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSSSS, "en-US", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSSSSS, "en-US", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSSSSSS, "en-US", ExpectedResult = "")]
        [TestCase(MomentFormat.SSSSSSSSS, "da-DK", ExpectedResult = "")]
        [TestCase(MomentFormat.Z, "en-US", ExpectedResult = "+02:00")]
        [TestCase(MomentFormat.Z, "da-DK", ExpectedResult = "+02:00")]
        [TestCase(MomentFormat.ZZ, "en-US", ExpectedResult = "+0200")]
        [TestCase(MomentFormat.ZZ, "da-DK", ExpectedResult = "+0200")]
        [TestCase(MomentFormat.X, "en-US", ExpectedResult = "526242625")]
        [TestCase(MomentFormat.X, "da-DK", ExpectedResult = "526242625")]
        [TestCase(MomentFormat.x, "en-US", ExpectedResult = "526242625123")]
        [TestCase(MomentFormat.x, "da-DK", ExpectedResult = "526242625123")]
        [TestCase(MomentFormat.LT, "en-US", ExpectedResult = "8:30 PM")]
        [TestCase(MomentFormat.LT, "da-DK", ExpectedResult = "20:30")]
        [TestCase(MomentFormat.LTS, "en-US", ExpectedResult = "8:30:25 PM")]
        [TestCase(MomentFormat.LTS, "da-DK", ExpectedResult = "20:30:25")]
        [TestCase(MomentFormat.L, "en-US", ExpectedResult = "09/04/1986")]
        [TestCase(MomentFormat.L, "da-DK", ExpectedResult = "04-09-1986")]
        [TestCase(MomentFormat.l, "en-US", ExpectedResult = "9/4/1986")]
        [TestCase(MomentFormat.l, "da-DK", ExpectedResult = "4-9-1986")]
        [TestCase(MomentFormat.LL, "en-US", ExpectedResult = "Thursday, September 4, 1986")]
        [TestCase(MomentFormat.LL, "da-DK", ExpectedResult = "4. september 1986")]
        [TestCase(MomentFormat.ll, "en-US", ExpectedResult = "Thu, Sep 4, 1986")]
        [TestCase(MomentFormat.ll, "da-DK", ExpectedResult = "4. sep 1986")]
        [TestCase(MomentFormat.LLL, "en-US", ExpectedResult = "Thursday, September 4, 1986 8:30 PM")]
        [TestCase(MomentFormat.LLL, "da-DK", ExpectedResult = "4. september 1986 20:30")]
        [TestCase(MomentFormat.lll, "en-US", ExpectedResult = "Thu, Sep 4, 1986 8:30 PM")]
        [TestCase(MomentFormat.lll, "da-DK", ExpectedResult = "4. sep 1986 20:30")]
        [TestCase(MomentFormat.LLLL, "en-US", ExpectedResult = "Thursday, September 4, 1986 8:30:25 PM")]
        [TestCase(MomentFormat.LLLL, "da-DK", ExpectedResult = "4. september 1986 20:30:25")]
        [TestCase(MomentFormat.llll, "en-US", ExpectedResult = "Thu, Sep 4, 1986 8:30:25 PM")]
        [TestCase(MomentFormat.llll, "da-DK", ExpectedResult = "4. sep 1986 20:30:25")]
        public string StandardFormat_With_StandardLocaleDefinition(MomentFormat format, string culture)
        {
            // Arrange
            LocaleDefinition localeDefinition = new StandardLocaleDefinition(culture);
            
            // Act
            string result = MomentFormatter.Format(DateTime, format, localeDefinition);

            // Assert
            return result;
        }

        [TestCase("dddd, MMMM D, YYYY h:mm A", "en-US", ExpectedResult = "Thursday, September 4, 1986 8:30 PM")]
        [TestCase("dddd, Do MMMM, YYYY HH:mm", "da-DK", ExpectedResult = "torsdag, 4. september, 1986 20:30")]
        [TestCase("dddd, Do MMMM, YYYY 'YYYY' HH:mm", "da-DK", ExpectedResult = "torsdag, 4. september, 1986 YYYY 20:30")]
        public string CustomFormat_With_StandardLocaleDefinition(string format, string culture)
        {
            // Arrange
            LocaleDefinition localeDefinition = new StandardLocaleDefinition(culture);
            
            // Act
            string result = MomentFormatter.Format(DateTime, format, localeDefinition);

            // Assert
            return result;
        }
    }
}