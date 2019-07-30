using System.Globalization;
using MomentJs.Net.Globalization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MomentJs.Net.Tests.Globalization
{
    [TestFixture]
    public class GlobalizationProviderTests
    {
        [OneTimeSetUp]
        public void GlobalizationProviderSetup()
        {
            GlobalizationProvider.Instance.Ordinal = culture =>
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
            };
        }

        [TestCase(1, "en-US", ExpectedResult = "1st")]
        [TestCase(2, "en-US", ExpectedResult = "2nd")]
        [TestCase(3, "en-US", ExpectedResult = "3rd")]
        [TestCase(4, "en-US", ExpectedResult = "4th")]
        [TestCase(5, "en-US", ExpectedResult = "5th")]
        [TestCase(21, "en-US", ExpectedResult = "21st")]
        [TestCase(22, "en-US", ExpectedResult = "22nd")]
        [TestCase(23, "en-US", ExpectedResult = "23rd")]
        [TestCase(24, "en-US", ExpectedResult = "24th")]
        [TestCase(25, "en-US", ExpectedResult = "25th")]
        [TestCase(1, "da-DK", ExpectedResult = "1.")]
        [TestCase(2, "da-DK", ExpectedResult = "2.")]
        [TestCase(3, "da-DK", ExpectedResult = "3.")]
        [TestCase(4, "da-DK", ExpectedResult = "4.")]
        [TestCase(5, "da-DK", ExpectedResult = "5.")]
        [TestCase(21, "da-DK", ExpectedResult = "21.")]
        [TestCase(22, "da-DK", ExpectedResult = "22.")]
        [TestCase(23, "da-DK", ExpectedResult = "23.")]
        [TestCase(24, "da-DK", ExpectedResult = "24.")]
        [TestCase(25, "da-DK", ExpectedResult = "25.")]
        public string Ordinal(int value, string cultureName)
        {
            CultureInfo culture = new CultureInfo(cultureName);

            return GlobalizationProvider.Instance.Ordinal(culture).Format(value);
        }

        [Test]
        public void Serialize()
        {
            // Arrange
            CultureInfo culture = new CultureInfo("en-US");

            // Act
            string result = JsonConvert.SerializeObject(GlobalizationProvider.Instance, new JsonSerializerSettings
            {
                Culture = culture
            });

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}