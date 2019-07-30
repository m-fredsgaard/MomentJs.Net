using System;
using System.Globalization;
using MomentJs.Net.Extensions;
using MomentJs.Net.Formats;
using NUnit.Framework;

namespace MomentJs.Net.Tests.Extensions
{
    public class DateTimeExtensionsTests
    {
        private static readonly DateTime DateTime = new DateTime(1986, 9, 4, 20, 30, 25, 123);

        [TestCase(DateFormat.LT, "en-US", ExpectedResult = "8:30 PM")]
        [TestCase(DateFormat.LT, "da-DK", ExpectedResult = "20:30")]
        [TestCase(DateFormat.LTS, "en-US", ExpectedResult = "8:30:25 PM")]
        [TestCase(DateFormat.LTS, "da-DK", ExpectedResult = "20:30:25")]
        [TestCase(DateFormat.L, "en-US", ExpectedResult = "09/04/1986")]
        [TestCase(DateFormat.L, "da-DK", ExpectedResult = "04-09-1986")]
        [TestCase(DateFormat.l, "en-US", ExpectedResult = "9/4/1986")]
        [TestCase(DateFormat.l, "da-DK", ExpectedResult = "4-9-1986")]
        [TestCase(DateFormat.LL, "en-US", ExpectedResult = "Thursday, September 4, 1986")]
        [TestCase(DateFormat.LL, "da-DK", ExpectedResult = "4. september 1986")]
        [TestCase(DateFormat.ll, "en-US", ExpectedResult = "Thu, Sep 4, 1986")]
        [TestCase(DateFormat.ll, "da-DK", ExpectedResult = "4. sep 1986")]
        [TestCase(DateFormat.LLL, "en-US", ExpectedResult = "Thursday, September 4, 1986 8:30 PM")]
        [TestCase(DateFormat.LLL, "da-DK", ExpectedResult = "4. september 1986 20:30")]
        [TestCase(DateFormat.lll, "en-US", ExpectedResult = "Thu, Sep 4, 1986 8:30 PM")]
        [TestCase(DateFormat.lll, "da-DK", ExpectedResult = "4. sep 1986 20:30")]
        [TestCase(DateFormat.LLLL, "en-US", ExpectedResult = "Thursday, September 4, 1986 8:30:25 PM")]
        [TestCase(DateFormat.LLLL, "da-DK", ExpectedResult = "4. september 1986 20:30:25")]
        [TestCase(DateFormat.llll, "en-US", ExpectedResult = "Thu, Sep 4, 1986 8:30:25 PM")]
        [TestCase(DateFormat.llll, "da-DK", ExpectedResult = "4. sep 1986 20:30:25")]
        public string DateFormat_With_LocaleDefinition(DateFormat formatToken, string cultureName)
        {
            // Arrange
            CultureInfo culture = new CultureInfo(cultureName);

            // Act
            string result = DateTime.Format(formatToken, culture);

            // Assert
            return result;
        }
    }
}