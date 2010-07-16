using System;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public static class FuncExtensions
    {
        public static Func<T> cache_result<T>(this Func<T> factory)
        {
            T item = default(T);

            return () => Equals(default(T),item) ? (item = factory()) : item;
        }
    }
}