using System.Globalization;

namespace MomentJs.Net.Globalization
{
    public delegate T ValueResolver<out T>(CultureInfo culture);
}