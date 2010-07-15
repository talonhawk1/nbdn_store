using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.extensions
{
    public static class EnumerableExtensions
    {
        public static void for_each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}