using System;
using System.Globalization;

namespace MomentJs.Net.Definitions
{
    public class StandardLocaleDefinition : LocaleDefinition
    {
        public StandardLocaleDefinition(CultureInfo culture, Func<int, string> ordinal = null) : base(culture, ordinal)
        {
        }

        public StandardLocaleDefinition(string cultureName, Func<int, string> ordinal = null) : base(cultureName,
            ordinal)
        {
        }
    }
}