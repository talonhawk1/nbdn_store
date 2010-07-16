using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.extensions
{
    public static class EnumerableExtensions
    {
        public static void each<T>(this IEnumerable<T> items, Action<T> action)
        {
            new List<T>(items).ForEach(action);
        }
    }
}