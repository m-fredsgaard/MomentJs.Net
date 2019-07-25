using System.Globalization;
using MomentJs.Net.Definitions;
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
            }

            public TestLocalDefinition(string cultureName) : base(cultureName)
            {
            }
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
    }
}