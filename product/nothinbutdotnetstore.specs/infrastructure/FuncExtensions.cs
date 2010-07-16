using System;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public static class FuncExtensions
    {
        public static Func<object> cache_result(this Func<object> factory)
        {
            return factory;
        }
    }
}