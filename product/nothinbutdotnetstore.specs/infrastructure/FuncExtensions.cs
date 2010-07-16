using System;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public static class FuncExtensions
    {
        public static Func<T> cache_result(this Func<T> factory)
        {
            object item = null;

            return () => item ?? (item = factory());
        }
    }
}