using System.Globalization;
using MomentJs.Net.Definitions;
using Newtonsoft.Json;
using NUnit.Framework;

// ReSharper disable once ClassNeverInstantiated.Local
// ReSharper disable UnusedMember.Local

namespace MomentJs.Net.Tests.Definitions
{
    [TestFixture]
    public class LocaleDefinitionTests
    {
        private class TestLocalDefinition : LocaleDefinition<TestLocalDefinition>
        {
            public TestLocalDefinition(CultureInfo culture) : base(culture)
            {
                Initialize(culture.Name);
            }

            public TestLocalDefinition(string cultureName) : base(cultureName)
            {
                Initialize(cultureName);
            }

            private void Initialize(string culture)
            {
                switch (culture)
                {
                    case "en-US":
                        Ordinal = () => @"function (number) { 
	var b = number % 10,
	output = ((number % 100 / 10) === 1) ? 'th' :
		(b === 1) ? 'st' :
		(b === 2) ? 'nd' :
		(b === 3) ? 'rd' : 'th';
	return number + output;
}";
                        break;
                    case "da-DK":
                        Ordinal = () => @"function test(value){return value+'.';}";
                        break;
                }
            }
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
        public string Ordinal(int value, string culture)
        {
            TestLocalDefinition localDefinition = new TestLocalDefinition(culture);
            return localDefinition.Ordinal().Format(value);
        }

        [Test]
        public void Current_ChangeCulture()
        {
            // Arrange
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            TestLocalDefinition enUsLocale = TestLocalDefinition.Current;

            Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("en-US"));

            // Act
            CultureInfo.CurrentCulture = new CultureInfo("da-DK");

            Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("da-DK"));

            TestLocalDefinition daDkLocale = TestLocalDefinition.Current;

            // Assert
            Assert.That(enUsLocale, Is.Not.Null);
            Assert.That(daDkLocale, Is.Not.Null);
            Assert.That(enUsLocale.Culture.Name, Is.EqualTo("en-US"));
            Assert.That(daDkLocale.Culture.Name, Is.EqualTo("da-DK"));
        }

        [Test]
        public void Serialize_LocaleDefinition()
        {
            // Arrange
            TestLocalDefinition localDefinition = new TestLocalDefinition("en-US")
            {
                Ordinal = () => "/d{1,3}"
            };

            // Act
            string result = JsonConvert.SerializeObject(localDefinition);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}