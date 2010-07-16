using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public static class FuncExtensions
    {
        static IDictionary<Func<object>, object> cache = new Dictionary<Func<object>, object>();

        public static Func<object> cache_result(this Func<object> factory)
        {
            return () => cache.ContainsKey(factory)
                ? cache[factory]
                : (cache[factory] = factory());
        }
    }
}