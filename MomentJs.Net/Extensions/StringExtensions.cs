namespace MomentJs.Net.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string NullIfEmpty(this string value)
        {
            return IsEmpty(value)
                ? null
                : value;
        }
    }
}