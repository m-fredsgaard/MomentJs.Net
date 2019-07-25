using System.Collections.Generic;
using System.Linq;

namespace Moment.Net.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> SkipNulls<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Where(value => value != null);
        }
    }
}