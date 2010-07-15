using System;

namespace nothinbutdotnetstore.infrastructure
{
    public class Log
    {
        public static Func<LoggerFactory> factory_resolver = delegate
        {
            throw new NotImplementedException("This needs to be configured by the application startup pipeline");
        };

        public static Logger an;
    }
}