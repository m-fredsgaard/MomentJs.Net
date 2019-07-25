using System.Globalization;

namespace MomentJs.Net.Definitions
{
    public class StandardLocaleDefinition : LocaleDefinition
    {
        public StandardLocaleDefinition(CultureInfo culture) : base(culture)
        {
        }

        public StandardLocaleDefinition(string cultureName) : base(cultureName)
        {
        }
    }
}