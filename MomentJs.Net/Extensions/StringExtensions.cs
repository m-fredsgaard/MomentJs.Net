namespace MomentJs.Net.Extensions
{
    public static class StringExtensions
    {
        internal static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        internal static string NullIfEmpty(this string value)
        {
            return IsEmpty(value)
                ? null
                : value;
        }
    }
}